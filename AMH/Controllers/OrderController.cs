using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
using AMH.Services.Contract;
using AMH.Infrastructure;
using AMH.Pages;
using DataTables.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AMH.Entities.V1;


namespace AMH.Controllers
{
    public class OrderController : BaseController
    {
        public readonly AbstractOrderAMHServices abstractOrderAMHServices;

        public OrderController(AbstractOrderAMHServices abstractOrderAMHServices)
        {
            this.abstractOrderAMHServices = abstractOrderAMHServices;
        }
        // GET: Wishlist
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult OrderAMH_Upsert(OrderAMH orderAMH)
        {
            // orderAMH.PaymentStatus = false;
            orderAMH.Createdby = (int)ProjectSession.Users_Id;
            orderAMH.User_Id = (int)ProjectSession.Users_Id;
            var result = abstractOrderAMHServices.OrderAMH_Upsert(orderAMH);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [ActionName(Actions.OrderAMH_All)]
        public ActionResult OrderAMH_All(int limit = 0, string Search = "", string FromDate = "", string ToDate = "")
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = limit;
            var Users_Id = (int)ProjectSession.Users_Id;
            var result = abstractOrderAMHServices.OrderAMH_All(pageParam, Search, 2, Users_Id, FromDate, ToDate);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [ActionName(Actions.MasterOrderStatus_Update)]
        public ActionResult MasterOrderStatus_Update(int orderid = 0)
        {
            var result = abstractOrderAMHServices.MasterOrderStatus_Update(orderid, 6);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Product_Allbyorder([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel
              , string ProductIds, string qunts, string prices)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractOrderAMHServices.Product_Allbyorder(pageParam, search, prices, qunts, ProductIds);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }

    }
} 