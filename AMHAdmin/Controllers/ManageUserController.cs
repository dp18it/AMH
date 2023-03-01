using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
using AMH.Services.Contract;
using AMHAdmin.Infrastructure;
using AMHAdmin.Pages;
using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AMH.Entities.V1;

namespace AMHAdmin.Controllers
{
    public class ManageUserController : BaseController
    {
        //public readonly AbstractUsersServices abstractUserServices;


        //public ManageUserController(/*AbstractUsersServices abstractUserServices)
        //{
        //    //this.abstractUserServices = abstractUserServices;

        //}

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            return View();
        }

    }
}