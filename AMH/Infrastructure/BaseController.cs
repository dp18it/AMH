using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Threading;
using System.Data.SqlClient;
using System.Data;
using AMH.Common;
using AMH.Pages;

namespace AMH.Infrastructure
{
    public class BaseController : Controller
    {
        #region Fields
        public static string AdminUserName;
        public static string CheckType;
        public static string CheckLastDate;
        #endregion

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
        /// <summary>
        /// Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //try
            //{
            //    bool IsAllow = false;
            //    HttpCookie reqCookie = Request.Cookies["UserTypeId"];
            //    HttpCookie reqCookieSalon = Request.Cookies["SalonId"];
            //    if (reqCookie != null)
            //    {
            //        int UserTypeId = ConvertTo.Integer(reqCookie.Value.ToString());
            //        int SalonId = 0;

            //        string ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToString();
            //        if (reqCookieSalon != null)
            //        { 
            //            SalonId = ConvertTo.Integer(ConvertTo.Base64Decode(reqCookieSalon.Value.ToString())); 
            //        }
            //        if (SalonId > 0 || ControllerName.ToString().Contains("Salons"))
            //        {
            //            if (UserTypeId == 1 && Pages.Controllers.AdminAccess.Contains(ControllerName))
            //            {
            //                IsAllow = true;
            //            }
            //            else if (UserTypeId == 2 && Pages.Controllers.SalonOwnerAccess.Contains(ControllerName))
            //            {
            //                IsAllow = true;
            //            }
            //            else if (UserTypeId == 3 && Pages.Controllers.EmployeeAccess.Contains(ControllerName))
            //            {
            //                IsAllow = true;
            //            }
            //            else if (UserTypeId == 4 && Pages.Controllers.CustomerAccess.Contains(ControllerName))
            //            {
            //                IsAllow = true;
            //            }
            //            else if (UserTypeId == 5 && Pages.Controllers.SellerAccess.Contains(ControllerName))
            //            {
            //                IsAllow = true;
            //            }
            //        }

            //    }
            //    if (IsAllow == true)
            //    {
            //        base.OnActionExecuting(filterContext);
            //    }
            //    else
            //    {
            //        throw new Exception("");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    filterContext.Result = new RedirectResult("~/Authentication/SignIn");
            //}

        }

    }
}