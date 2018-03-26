using Airports.App_Start;
using Airports.Base.Exceptions;
using Airports.BLL.Managers;
using Airports.Controllers;
using AirportScheduler;
using AutoMapper;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.UI;

namespace Airports
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg => {
                MapperAutoConfig.Configure(cfg);
            });

            container.Register<IAirportManager, AirportManager>(Lifestyle.Transient);
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            AirportLoaderScheduler.Start();
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            var httpContext = HttpContext.Current;

            if (ex is AirportException && httpContext != null)
            {
                RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;

                httpContext.Response.Clear();
                string controllerName = requestContext.RouteData.GetRequiredString("controller");
                IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
                IController controller = factory.CreateController(requestContext, controllerName);
                ControllerContext controllerContext = new ControllerContext(requestContext, (ControllerBase)controller);

                JsonResult jsonResult = new JsonResult
                {
                    Data = new { success = false, message = ex.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
                jsonResult.ExecuteResult(controllerContext);
                httpContext.Response.End();
            }
            else
            {
                httpContext.Response.Redirect("~/Error");
            }
        }
    }
}
