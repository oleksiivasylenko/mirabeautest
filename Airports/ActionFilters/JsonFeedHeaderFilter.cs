using Airports.BLL.Managers;
using System;
using System.Web.Mvc;

namespace Airports.Controllers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class JsonFeedHeader : ActionFilterAttribute
    {
        private readonly IAirportManager _airportManager = new AirportManager();

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var needSendHeader = _airportManager.NeedSendHeader();
            if (needSendHeader)
                context.RequestContext.HttpContext.Response.Headers.Add("from-feed", "sure");

            base.OnActionExecuted(context);
        }
    }

}