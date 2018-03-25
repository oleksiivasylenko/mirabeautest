using System.Collections.Generic;
using System.Threading.Tasks;
using Airports.Base;
using Airports.Base.DBModels;
using Airports.Base.DTO;
using Airports.Base.Enums;
using Airports.Base.Exceptions;
using Airports.Base.Filters;
using Airports.Base.Helpers;
using Airports.Base.ViewModels;
using Airports.DAL;

namespace Airports.BLL.Managers
{
    public class AirportManager : IAirportManager
    {
        public async Task<List<Airport>> LoadAllAirports()
        {
            var airportDTOs = await ExternalResourcesLoader.GetListAsync<AirportDTO>(GlobalVariables.JsonUrl);

            var airports = new List<Airport>();
            for (int i = 0; i < airportDTOs.Count; i++)
                airports.Add(new Airport(airportDTOs[i]));

            return airports;
        }

        public AirportPagedList FindAirports(AirportFilter filter)
        {
            return LiteDBData.GetAirports(filter);
        }

        public DistanceViewModel CalculateDistance(string fromIATA, string toIATA)
        {
            var from = fromIATA.Trim();
            var to = toIATA.Trim();

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                throw new EmptyParameterException(GlobalVariables.ErrorMessages.PleaseEnterFromAndTo);

            var airportFrom = LiteDBData.GetAirportByIATA(from);
            var airportTo = LiteDBData.GetAirportByIATA(to);

            var distance = GeoDistanceCalculator.Calculate(airportFrom.Lat, airportFrom.Lon, airportTo.Lat, airportTo.Lon, DistanceMeasuringUnit.Kilometers);

            return new DistanceViewModel(distance, airportFrom, airportTo);
        }

        public bool NeedSendHeader()
        {
            return LiteDBData.NeedSendHeader();
        }
    }
}
