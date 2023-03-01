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
    public class CityController : BaseController
    {
        public readonly AbstractCityServices abstractCityServices;
        public readonly AbstractStateServices abstractStateServices;

        public CityController(AbstractCityServices abstractCityServices,
            AbstractStateServices abstractStateServices)
        {
            this.abstractCityServices = abstractCityServices;
            this.abstractStateServices = abstractStateServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            ViewBag.StateDrp = StateDrp();
            return View();
        }

        [HttpPost]
        public IList<SelectListItem> StateDrp()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;

            var result = abstractStateServices.State_All(pageParam, "");

            foreach (var master in result.Values)
            {
                items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
            }

            return items;
        }

        public JsonResult City_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel
            ,int StateId=0)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractCityServices.City_All(pageParam, search,StateId);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult City_Upsert(City City)
        {
            if (City.Id > 0)
            {
                City.Updatedby = (int)ProjectSession.AdminId;
            }
            else
            {
                City.Createdby = (int)ProjectSession.AdminId;
            }

            var result = abstractCityServices.City_Upsert(City);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    
        [HttpPost]
        public JsonResult City_ById(int Id = 0)
        {
            SuccessResult<AbstractCity> successResult = abstractCityServices.City_ById(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult City_ActInact(int Id)
        {
            SuccessResult<AbstractCity> admin = new SuccessResult<AbstractCity>();

            try
            {
                int Updatedby = (int)ProjectSession.AdminId;
                admin = abstractCityServices.City_ActInact(Id, Updatedby);
            }
            catch (Exception ex)
            {
                admin.Code = 400;
                admin.Message = ex.Message;
            }
            admin.Item = null;
            return Json(admin, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult City_Delete(int Id)
        {
            int Deletedby = (int)ProjectSession.AdminId;

            var result = abstractCityServices.City_Delete(Id, Deletedby);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}