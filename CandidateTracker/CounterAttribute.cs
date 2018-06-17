using CandidateTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidateTracker
{
    public class CounterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var CR = new CandidateRepository(Properties.Settings.Default.ConStr);
            filterContext.Controller.ViewBag.PendingCount = CR.GetPendingCount();
            filterContext.Controller.ViewBag.ConfirmedCount = CR.GetConfirmedCount();
            filterContext.Controller.ViewBag.DeclinedCount = CR.GetDeclinedCount();
            base.OnActionExecuted(filterContext);
        }
    }
}