using DataTables.Mvc;
using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
using AMH.Entities.V1;
using AMH.Services.Contract;
using AMHAdmin.Infrastructure;
using AMHAdmin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMHAdmin.Infrastructure;

namespace AMHAdmin.Controllers
{
    public class ChangePasswordController : BaseController
    {
        //#region Fields
        //private readonly AbstractAdminServices abstractAdminServices;
        //#endregion

        //#region Ctor
        //public ChangePasswordController(AbstractAdminServices abstractAdminServices)
        //{
        //    this.abstractAdminServices = abstractAdminServices;
        //}
        //#endregion

        //#region Methods
        //[HttpGet]
        //[ActionName(Actions.ChangePassword)]
        //public ActionResult ChangePassword()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ActionName(Actions.ChangePassword)]
        //public ActionResult ChangePassword(long Id, string OldPassword, string NewPassword, string ConfirmPassword)
        //{
        //    SuccessResult<AbstractAdmin> result = abstractAdminServices.Admin_ChangePassword(Id, OldPassword, NewPassword, ConfirmPassword);

        //    var welcome = "Greetings From Ginny Buddy.";
        //    EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "Email : " + result.Item.Email + " , Password : " + result.Item.Password + " Information Updated", result.Item.Password);

        //    return Json(result, JsonRequestBehavior.AllowGet);

        //}

        //#endregion
    }
}