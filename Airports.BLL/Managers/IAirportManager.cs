using Airports.Base.DBModels;
using Airports.Base.DTO;
using Airports.Base.Filters;
using Airports.Base.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airports.BLL.Managers
{
    public interface IAirportManager
    {
        Task<List<Airport>> LoadAllAirports();

        AirportPagedList FindAirports(AirportFilter filter);

        DistanceViewModel CalculateDistance(string fromIATA, string toIATA);

        bool NeedSendHeader();
    }
}
