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

namespace AMH.Controllers
{
    public class WishlistController : BaseController
    {
        public readonly AbstractWishlistServices abstractWishlistServices;

        public WishlistController(AbstractWishlistServices abstractWishlistServices)
        {
            this.abstractWishlistServices = abstractWishlistServices;
        }
        public ActionResult Index()
        {
            if(ProjectSession.Users_Id == 0 || ProjectSession.Users_Id == null)
            {
                return RedirectToAction("Login", "Myaccount", new { area = "" });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public JsonResult Wishlist_Upsert(Wishlist wishlist)
        {
            wishlist.Users_Id =  (int)ProjectSession.Users_Id;
            var result = abstractWishlistServices.Wishlist_Upsert(wishlist);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
         [HttpPost]
        public JsonResult Wishlist_Delete(int Product_Id)
        {
            var Users_Id =  (int)ProjectSession.Users_Id;
            var result = abstractWishlistServices.Wishlist_Delete(Product_Id, Users_Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName(Actions.Wishlist_All)]
        public ActionResult Wishlist_All(int limit = 0, string Search = "")
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = limit;
            var Users_Id = (int)ProjectSession.Users_Id;
            var result = abstractWishlistServices.Wishlist_All(pageParam, Search, Users_Id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}