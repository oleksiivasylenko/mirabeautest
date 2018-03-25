using System.Web.Mvc;

namespace Airports.Controllers
{
    public class ErrorController: Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Regular Error";
            return View();
        }
    }
}