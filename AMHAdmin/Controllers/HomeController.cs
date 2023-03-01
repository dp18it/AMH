using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
using AMH.Services.Contract;
using AMHAdmin.Infrastructure;
using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMHAdmin.Controllers
{
    public class HomeController : BaseController
    {
        public readonly AbstractAdminServices abstractAdminServices;


        public HomeController(
           AbstractAdminServices abstractAdminServices)

        {
            this.abstractAdminServices = abstractAdminServices;

        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Home_All()
        {
            //int Id = ProjectSession.AdminId;
            var result = abstractAdminServices.Home_All();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public JsonResult Requests_ByStatusCount()
        //{
        //    SuccessResult<AbstractRequestsCount> result = abstractRequestsServices.Requests_ByStatusCount();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult Requests_Urgent(long UserId = 0, long DeliveryExecutiveId = 0)
        //{
        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;

        //    PagedList<AbstractRequests> result = abstractRequestsServices.Requests_Urgent(pageParam, UserId, DeliveryExecutiveId);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult DeliveryExecutiveLatLong_Map()
        //{
        //    PagedList<AbstractDeliveryExecutiveLatLong> result = abstractDeliveryExecutiveLatLongServices.DeliveryExecutiveLatLong_Map();

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult Requests_Attended(string ActionFormDate = "", string ActionToDate = "")
        //{
        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;

        //    PagedList<AbstractRequests> result = abstractRequestsServices.Requests_Attended(pageParam, ActionFormDate, ActionToDate);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}