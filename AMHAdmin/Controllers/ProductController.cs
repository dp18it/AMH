using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
using AMH.Services.Contract;
using AMHAdmin.Infrastructure;
using AMHAdmin.Pages;
using DataTables.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AMH.Entities.V1;

namespace AMHAdmin.Controllers
{
    public class ProductController : BaseController
    {
        public readonly AbstractProductServices abstractProductServices;
        public readonly AbstractSubCategoryServices abstractSubCategoryServices;

        public ProductController( AbstractProductServices abstractProductServices,
             AbstractSubCategoryServices abstractSubCategoryServices)            
        {
            this.abstractProductServices = abstractProductServices;
            this.abstractSubCategoryServices = abstractSubCategoryServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            ViewBag.SubCategoryDrp = SubCategoryDrp();
            return View();
        }
        [HttpPost]
        public IList<SelectListItem> SubCategoryDrp()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;

            var result = abstractSubCategoryServices.SubCategory_All(pageParam, "", 2);

            foreach (var master in result.Values)
            {
                items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Subcat_Id) });
            }

            return items;
        }


        public JsonResult Product_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractProductServices.Product_All(pageParam, search,2,0,0,0,0,0);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Product_Upsert(HttpPostedFileBase files, HttpPostedFileBase files1, HttpPostedFileBase files2, HttpPostedFileBase files3, Product Product)
        {
            if (Product.Product_Id > 0)
            {
                Product.Updatedby = (int)ProjectSession.AdminId;
            }
            else
            {
                Product.Createdby = (int)ProjectSession.AdminId;
            }
           
            if (files != null)
            {
                string basePath = "ProductImg/";
                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + "_" + Path.GetFileName(files.FileName);
                if (!Directory.Exists(Path.Combine(HttpContext.Server.MapPath("~/" + basePath))))
                {
                    Directory.CreateDirectory(HttpContext.Server.MapPath("~/" + basePath));
                }
                Product.Image = basePath + fileName;
                files.SaveAs(HttpContext.Server.MapPath("~/" + basePath + fileName));
            } 
            if (files1 != null)
            {
                string basePath = "ExtraProductImg/";
                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + "_" + Path.GetFileName(files1.FileName);
                if (!Directory.Exists(Path.Combine(HttpContext.Server.MapPath("~/" + basePath))))
                {
                    Directory.CreateDirectory(HttpContext.Server.MapPath("~/" + basePath));
                }
                Product.ExtraImage1 = basePath + fileName;
                files1.SaveAs(HttpContext.Server.MapPath("~/" + basePath + fileName));
            } 
            if (files2 != null)
            {
                string basePath = "ExtraProductImg/";
                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + "_" + Path.GetFileName(files2.FileName);
                if (!Directory.Exists(Path.Combine(HttpContext.Server.MapPath("~/" + basePath))))
                {
                    Directory.CreateDirectory(HttpContext.Server.MapPath("~/" + basePath));
                }
                Product.ExtraImage2 = basePath + fileName;
                files2.SaveAs(HttpContext.Server.MapPath("~/" + basePath + fileName));
            } 
            if (files3 != null)
            {
                string basePath = "ExtraProductImg/";
                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + "_" + Path.GetFileName(files3.FileName);
                if (!Directory.Exists(Path.Combine(HttpContext.Server.MapPath("~/" + basePath))))
                {
                    Directory.CreateDirectory(HttpContext.Server.MapPath("~/" + basePath));
                }
                Product.ExtraImage3 = basePath + fileName;
                files3.SaveAs(HttpContext.Server.MapPath("~/" + basePath + fileName));
            }
            var result = abstractProductServices.Product_Upsert(Product);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    
        [HttpPost]
        public JsonResult Product_ById(int Product_Id = 0)
        {
            SuccessResult<AbstractProduct> successResult = abstractProductServices.Product_ById(Product_Id, 0);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Product_ActInAct(int Product_Id)
        {
            SuccessResult<AbstractProduct> admin = new SuccessResult<AbstractProduct>();

            try
            {
                int Updatedby = (int)ProjectSession.AdminId;
                admin = abstractProductServices.Product_ActInact(Product_Id, Updatedby);
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
        public JsonResult Product_Delete(int Product_Id)
        {
            int DeletedBy = (int)ProjectSession.AdminId;

            var result = abstractProductServices.Product_Delete(Product_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}