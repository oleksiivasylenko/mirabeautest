using Airports.Base.ViewModels;
using Airports.Base.Filters;
using Airports.BLL.Managers;
using PagedList;
using System.Web.Mvc;
using Airports.Base.DBModels;
using Airports.Base.Exceptions;

namespace Airports.Controllers
{
    [JsonFeedHeader]
    public class AirportController : BaseController
    {
        #region ctors

        private readonly IAirportManager _airportManager;
        public AirportController(IAirportManager airportManager)
        {
            _airportManager = airportManager;
        }

        #endregion

        #region actions 

        
        public ActionResult Index(AirportFilter filter)
        {
            PoulateViewBag(filter);

            var airportPaged = _airportManager.FindAirports(filter);
            return View(new StaticPagedList<AirportViewModel>(airportPaged.Airports, filter.Page, filter.PageSize, airportPaged.TotalItems));
        }

        [Route("calculate")]
        public ActionResult Calculate(string from, string to)
        {
            return Json(new Response<DistanceViewModel>(_airportManager.CalculateDistance(from, to)));
        }

        [Route("distance")]
        public ActionResult Distance(string from, string to)
        {
            try
            {
                return View("Distance", _airportManager.CalculateDistance(from, to));
            }
            catch (AirportException)
            {
                return View("Distance", new DistanceViewModel(0, new Airport(from), new Airport(to)) { Message = "Please provide correct IATAs!"});
            }
        }

        #endregion

        #region helpers

        private void PoulateViewBag(AirportFilter filter)
        {
            ViewBag.Continent = filter.Continent;
            ViewBag.ISO = filter.ISO;
            ViewBag.Size = filter.Size;
            ViewBag.Type = filter.Type;
            ViewBag.Name = filter.Name;
        }

        #endregion
    }
}