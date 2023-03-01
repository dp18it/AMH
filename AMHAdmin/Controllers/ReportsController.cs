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
    public class ReportsController : BaseController
    {
        public readonly AbstractProductServices abstractProductServices;
        public readonly AbstractUsersServices abstractUsersServices;
        public ReportsController(
            AbstractProductServices abstractProductServices, AbstractUsersServices abstractUsersServices)
        {
            this.abstractProductServices = abstractProductServices;
            this.abstractUsersServices = abstractUsersServices;
        }

        [ActionName(Actions.UsersListing)]
        public ActionResult UsersListing()
        {
            return View();
        }

        [ActionName(Actions.FeedbackListing)]
        public ActionResult FeedbackListing()
        {
            ViewBag.ProductDrp = ProductDrp();
            ViewBag.UsersDrp = UsersDrp();
            return View();
        }

        [ActionName(Actions.OrderListing)]
        public ActionResult OrderListing()
        {
            ViewBag.ProductDrp = ProductDrp();
            ViewBag.UsersDrp = UsersDrp();
            return View();
        }
        
        [ActionName(Actions.PaymentListing)]
        public ActionResult PaymentListing()
        {
            return View();
        }

        [HttpPost]
        public IList<SelectListItem> ProductDrp()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;

            var result = abstractProductServices.Product_All(pageParam, "", 2, 0, 0, 0, 0, 0);

            foreach (var master in result.Values)
            {
                items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Product_Id) });
            }

            return items;
        }
        [HttpPost]
        public IList<SelectListItem> UsersDrp()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;

            var result = abstractUsersServices.Users_All(pageParam, "", 0, 0, 2, "", "");

            foreach (var master in result.Values)
            {
                items.Add(new SelectListItem() { Text = master.FirstName.ToString(), Value = Convert.ToString(master.Users_Id) });
            }

            return items;
        }
    }
}