using Airports.BLL.Managers;
using Airports.DAL;
using Quartz;
using System.Linq;
using System.Threading.Tasks;

namespace AirportScheduler
{
    public class AirportLoader : IJob
    {
        private readonly IAirportManager _airportManager;

        public AirportLoader()
        {
            _airportManager = new AirportManager();
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var airports = await _airportManager.LoadAllAirports();
                LiteDBData.SaveAirports(airports.OrderBy(a => a.IATA).ToList());
                LiteDBData.AirportsWereUpdated();
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }
    }
}
