using AMH.Common;
using AMHAdmin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using AMH.Entities.Contract;
using AMH.Services.Contract;
using AMH.Common.Paging;
using AMH.Entities.V1;

namespace AMHAdmin.Infrastructure
{

    public class BaseController : Controller
    {
        public BaseController()
        {

        }
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }


        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    try
        //    {

        //        filterContext.Result = new RedirectResult("~/Customer/Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        filterContext.Result = new RedirectResult("~/Customer/Index");
        //    }
        //}
    }
}