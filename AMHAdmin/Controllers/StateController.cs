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
    public class StateController : BaseController
    {
        public readonly AbstractStateServices abstractStateServices;
        
        public StateController( AbstractStateServices abstractStateServices)            
        {
            this.abstractStateServices = abstractStateServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult State_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractStateServices.State_All(pageParam, search);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult State_Upsert(State State)
        {
            if (State.Id > 0)
            {
                State.Updatedby = (int)ProjectSession.AdminId;
            }
            else
            {
                State.Createdby = (int)ProjectSession.AdminId;
            }

            var result = abstractStateServices.State_Upsert(State);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    
        [HttpPost]
        public JsonResult State_ById(int Id = 0)
        {
            SuccessResult<AbstractState> successResult = abstractStateServices.State_ById(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult State_ActInact(int Id)
        {
            SuccessResult<AbstractState> admin = new SuccessResult<AbstractState>();

            try
            {
                int Updatedby = (int)ProjectSession.AdminId;
                admin = abstractStateServices.State_ActInact(Id, Updatedby);
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
        public JsonResult State_Delete(int Id)
        {
            int Deletedby = (int)ProjectSession.AdminId;

            var result = abstractStateServices.State_Delete(Id, Deletedby);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}