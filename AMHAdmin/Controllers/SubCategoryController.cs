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
    public class SubCategoryController : BaseController
    {
        public readonly AbstractSubCategoryServices abstractSubCategoryServices;
        public readonly AbstractCategoryServices abstractCategoryServices;

        public SubCategoryController(AbstractSubCategoryServices abstractSubCategoryServices,
            AbstractCategoryServices abstractCategoryServices)
        {
            this.abstractSubCategoryServices = abstractSubCategoryServices;
            this.abstractCategoryServices = abstractCategoryServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            ViewBag.CategoryDrp = CategoryDrp();
            return View();
        }

        [HttpPost]
        public IList<SelectListItem> CategoryDrp()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;

            var result = abstractCategoryServices.Category_All(pageParam, "", 2);

            foreach (var master in result.Values)
            {
                items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Category_Id) });
            }

            return items;
        }

        public JsonResult SubCategory_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractSubCategoryServices.SubCategory_All(pageParam, search, 2);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult SubCategory_Upsert(SubCategory SubCategory)
        {
            if (SubCategory.Subcat_Id > 0)
            {
                SubCategory.Updatedby = (int)ProjectSession.AdminId;
            }
            else
            {
                SubCategory.Createdby = (int)ProjectSession.AdminId;
            }

            var result = abstractSubCategoryServices.SubCategory_Upsert(SubCategory);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SubCategory_ById(int Subcat_Id = 0)
        {
            SuccessResult<AbstractSubCategory> successResult = abstractSubCategoryServices.SubCategory_ById(Subcat_Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SubCategory_ActInAct(int Subcat_Id)
        {
            SuccessResult<AbstractSubCategory> admin = new SuccessResult<AbstractSubCategory>();

            try
            {
                int Updatedby = (int)ProjectSession.AdminId;
                admin = abstractSubCategoryServices.SubCategory_ActInact(Subcat_Id, Updatedby);
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
        public JsonResult SubCategory_Delete(int Subcat_Id)
        {
            int DeletedBy = (int)ProjectSession.AdminId;

            var result = abstractSubCategoryServices.SubCategory_Delete(Subcat_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}