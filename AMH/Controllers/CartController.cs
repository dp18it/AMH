using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
using AMH.Entities.V1;
using AMH.Infrastructure;
using AMH.Services.Contract;
using AMH.Pages;
using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace AMH.Controllers
{
    public class CartController : BaseController
    {
        private readonly AbstractCartServices abstractCartServices;


        public CartController(AbstractCartServices abstractCartServices)
        {
            this.abstractCartServices = abstractCartServices;
        }
        public ActionResult Index()
        {
            if (ProjectSession.Users_Id == 0 || ProjectSession.Users_Id == null)
            {
                return RedirectToAction("Login", "Myaccount", new { area = "" });
            }
            else
            {
                return View();
            }
        }
        public ActionResult Checkout()
        {
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["StripePublishableKey"];
            return View();
        }

        [HttpPost]
        public JsonResult Cart_Upsert(Cart cart,int qunt = 1)
        {
            cart.User_Id = (int)ProjectSession.Users_Id;
            cart.Quantity = qunt;
            var result = abstractCartServices.Cart_Upsert(cart);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Cart_Delete(int Product_Id)
        {
            int DeletedBy = (int)ProjectSession.Users_Id;

            var result = abstractCartServices.Cart_Delete(Product_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [ActionName(Actions.Cart_All)]
        public ActionResult Cart_All(int limit = 0, string Search = "")
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = limit;
            var Users_Id = (int)ProjectSession.Users_Id;
            var result = abstractCartServices.Cart_All(pageParam, Search, Users_Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}