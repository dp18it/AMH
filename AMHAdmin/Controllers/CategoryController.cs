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
    public class CategoryController : BaseController
    {
        public readonly AbstractCategoryServices abstractCategoryServices;
        
        public CategoryController( AbstractCategoryServices abstractCategoryServices)            
        {
            this.abstractCategoryServices = abstractCategoryServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Category_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractCategoryServices.Category_All(pageParam, search,2);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Category_Upsert(Category Category)
        {
            if (Category.Category_Id > 0)
            {
                Category.Updatedby = (int)ProjectSession.AdminId;
            }
            else
            {
                Category.Createdby = (int)ProjectSession.AdminId;
            }

            var result = abstractCategoryServices.Category_Upsert(Category);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    
        [HttpPost]
        public JsonResult Category_ById(int Category_Id = 0)
        {
            SuccessResult<AbstractCategory> successResult = abstractCategoryServices.Category_ById(Category_Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Category_ActInAct(int Category_Id)
        {
            SuccessResult<AbstractCategory> admin = new SuccessResult<AbstractCategory>();

            try
            {
                int Updatedby = (int)ProjectSession.AdminId;
                admin = abstractCategoryServices.Category_ActInact(Category_Id, Updatedby);
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
        public JsonResult Category_Delete(int Category_Id)
        {
            int DeletedBy = (int)ProjectSession.AdminId;

            var result = abstractCategoryServices.Category_Delete(Category_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}