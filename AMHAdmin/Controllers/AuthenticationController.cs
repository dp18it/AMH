using AMH.Common;
using AMHAdmin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMH.Entities.V1;
using AMH.Services.Contract;
using AMH.Entities.Contract;
using AMHAdmin.Infrastructure;

namespace AMHAdmin.Controllers
{
    public class AuthenticationController : BaseController
    {
        #region Fields
        private readonly AbstractAdminServices abstractAdminServices;
        #endregion
        #region Ctor
        public AuthenticationController(AbstractAdminServices abstractAdminServices)
        {
            this.abstractAdminServices = abstractAdminServices;
        }
        #endregion

        #region Methods

        public ActionResult Signin()
        {
            return View();
        }
        [HttpGet]
        [ActionName(Actions.ChangePassword)]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ActionName(Actions.ChangePassword)]
        public ActionResult ChangePassword(int Id, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            SuccessResult<AbstractAdmin> result = abstractAdminServices.Admin_ChangePassword(Id, OldPassword, NewPassword, ConfirmPassword);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Signin(string Email, string Password)
        {
            SuccessResult<AbstractAdmin> result = abstractAdminServices.Admin_SignIn(Email, Password);
            if (result.Code == 200 && result.Item != null)
            {
                Session.Clear();
                ProjectSession.AdminId = result.Item.Admin_Id;
                ProjectSession.LoginAdminEmail = result.Item.Email;

                HttpCookie cookie = new HttpCookie("AdminLogin");
                cookie.Values.Add("Id", result.Item.Admin_Id.ToString());
                cookie.Values.Add("Email", result.Item.Email);

                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Signout()
        {
            var result = abstractAdminServices.Admin_SignOut();
            if (result == true)
            {
                if (Request.Cookies["AdminLogin"] != null)
                {
                    string[] myCookies = Request.Cookies.AllKeys;
                    foreach (string cookie in myCookies)
                    {
                        Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                    }
                }
            }


            Session.Clear();
            Session.Abandon();

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction(Actions.Signin, Pages.Controllers.Authentication);
        }


        #endregion
    }
}