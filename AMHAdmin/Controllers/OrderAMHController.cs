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
    public class OrderAMHController : BaseController
    {
        public readonly AbstractOrderAMHServices abstractOrderAMHServices;
        public readonly AbstractUsersServices abstractUsersServices;

        public OrderAMHController(AbstractOrderAMHServices abstractOrderAMHServices,
            AbstractUsersServices abstractUsersServices)
        {
            this.abstractOrderAMHServices = abstractOrderAMHServices;
            this.abstractUsersServices = abstractUsersServices;

        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            ViewBag.UsersDrp = UsersDrp();
            return View();
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

        public JsonResult OrderAMH_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel
             , int Users_Id = 0, string FromDate="", string ToDate="")
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractOrderAMHServices.OrderAMH_All(pageParam, search,2, Users_Id, FromDate, ToDate);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
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
                var response = abstractOrderAMHServices.Product_Allbyorder(pageParam, search, prices , qunts, ProductIds);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult MasterOrderStatus_Update(int Order_Id,int Status_Id)
        {

            var result = abstractOrderAMHServices.MasterOrderStatus_Update(Order_Id, Status_Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}