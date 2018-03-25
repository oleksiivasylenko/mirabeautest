using Airports.Base;
using Airports.Base.DBModels;
using Airports.Base.DTO;
using Airports.Base.Enums;
using Airports.Base.Exceptions;
using Airports.Base.Extensions.LinqKit;
using Airports.Base.Filters;
using Airports.Base.ViewModels;
using Airports.Extensions;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Airports.DAL
{
    public static class LiteDBData
    {

        #region ctors

        public static void SaveAirports(List<Airport> airports)
        {
            using (var db = new LiteDatabase(GlobalVariables.LiteDbPath))
            {
                var col = db.GetCollection<Airport>("airports");
                col.Delete(x => true);
                col.InsertBulk(airports);
            }
        }

        #endregion

        #region functions 

        public static AirportPagedList GetAirports(AirportFilter filter)
        {
            using (var db = new LiteDatabase(GlobalVariables.LiteDbPath))
            {
                var skip = (filter.Page - 1) * filter.PageSize;
                var col = db.GetCollection<Airport>(GlobalVariables.DbCollectionName);

                var searchCondition = SearchConditionBuilder(filter);
                var filteredAirports = col.Find(searchCondition)
                .Skip(skip).Take(filter.PageSize)
                .Select(a => a.ToViewModel<AirportViewModel>()).ToList();

                return new AirportPagedList(filteredAirports, col.Count(searchCondition));
            }
        }

        public static bool NeedSendHeader()
        {
            using (var db = new LiteDatabase(GlobalVariables.LiteDbPath))
            {
                var col = db.GetCollection<AppInfo>(GlobalVariables.AppInfoDbCollectionName);
                var appInfo = col.FindOne(a => a.Name == GlobalVariables.AppInfoDbCollectionName);

                if (appInfo != null && appInfo.NeedSendHeader)
                {
                    appInfo.NeedSendHeader = false;
                    col.Update(appInfo);

                    return true;
                }

                return false;
            }
        }

        public static void AirportsWereUpdated()
        {
            using (var db = new LiteDatabase(GlobalVariables.LiteDbPath))
            {
                var col = db.GetCollection<AppInfo>(GlobalVariables.AppInfoDbCollectionName);
                var appInfo = col.FindOne(a => a.Name == GlobalVariables.AppInfoDbCollectionName);

                if (appInfo == null)
                    col.Insert(new AppInfo());
                else
                {
                    appInfo.NeedSendHeader = true;
                    col.Update(appInfo);
                }
            }
        }

        public static Airport GetAirportByIATA(string iata)
        {
            using (var db = new LiteDatabase(GlobalVariables.LiteDbPath))
            {
                var col = db.GetCollection<Airport>(GlobalVariables.DbCollectionName);
                var airport = col.FindOne(a => a.IATA.ToLower() == iata.ToLower());

                if (airport == null)
                    throw new ItemNotFoundException();

                return airport;
            }
        }

        #endregion

        #region private function

        private static Expression<Func<Airport, bool>> SearchConditionBuilder(AirportFilter filter)
        {
            var predicate = PredicateBuilder.True<Airport>();

            if (filter.Continent.HasValue && filter.Continent != AirportContinent.All)
                predicate = predicate.And(x => x.Continent == filter.Continent);

            if (filter.Size.HasValue && filter.Size != AirportSize.Any)
                predicate = predicate.And(x => x.Size == filter.Size);

            if (filter.Type.HasValue && filter.Type != AirportType.Any)
                predicate = predicate.And(x => x.Type == filter.Type);

            if (!string.IsNullOrWhiteSpace(filter.ISO))
            {
                var isoTxt = filter.ISO.ToLower();
                predicate = predicate.And(x => x.ISO.ToLower().Contains(isoTxt) || x.Country.ToLower().Contains(isoTxt));
            }

            if (!string.IsNullOrWhiteSpace(filter.Name))
                predicate = predicate.And(x => x.Name.ToLower().Contains(filter.Name.ToLower()));

            return predicate;
        }

        #endregion
    }
}
