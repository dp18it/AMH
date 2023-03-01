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
using AMHAdmin.Infrastructure;

namespace AMHAdmin.Controllers
{
    public class CartController : BaseController
    {
        public readonly AbstractCartServices abstractCartServices;
        
        public CartController( AbstractCartServices abstractCartServices)            
        {
            this.abstractCartServices = abstractCartServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Cart_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractCartServices.Cart_All(pageParam, search,2);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Cart_Upsert(Cart Cart)
        {
           
            var result = abstractCartServices.Cart_Upsert(Cart);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Cart_Delete(int Cart_Id)
        {
            int DeletedBy = (int)ProjectSession.AdminId;

            var result = abstractCartServices.Cart_Delete(Cart_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}