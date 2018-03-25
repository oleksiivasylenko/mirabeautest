using Airports.Base.ViewModels;
using Airports.Base.Filters;
using Airports.BLL.Managers;
using PagedList;
using System.Web.Mvc;

namespace Airports.Controllers
{
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
            AddResponseHeader();

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
            return View("Distance", _airportManager.CalculateDistance(from, to));
        }

        #endregion

        #region helpers

        private void AddResponseHeader()
        {
            if (HttpContext != null && _airportManager.NeedSendHeader())
                HttpContext.Response.AppendHeader("from-feed", "sure");
        }

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