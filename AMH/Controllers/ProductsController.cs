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
    public class ProductsController : BaseController
    {

        public readonly AbstractProductServices abstractProductServices;
        public readonly AbstractSubCategoryServices abstractSubCategoryServices;
        public readonly AbstractCategoryServices abstractCategoryServices;
        public ProductsController(AbstractProductServices abstractProductServices,
             AbstractSubCategoryServices abstractSubCategoryServices,
             AbstractCategoryServices abstractCategoryServices)
        {
            this.abstractProductServices = abstractProductServices;
            this.abstractSubCategoryServices = abstractSubCategoryServices;
            this.abstractCategoryServices = abstractCategoryServices;
        }
        public ActionResult Index(int Cat_Id = 0,string srech = "")
        {
            ViewBag.CategoryDrp = CategoryDrp();
            ViewBag.srech = srech;
            ViewBag.Cat_Id = Cat_Id;
            ViewBag.SubCategoryDrp = SubCategoryDrp();
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
        public ActionResult SingleProduct(int Product_Id)
        {
            ViewBag.Product_Id = Product_Id;
            return View();
        }
        [HttpGet]
        [ActionName(Actions.Product_All)]
        public ActionResult Product_All(int limit=0,string Search = "", int Cat_Id = 0,int Subcat_Id = 0,int FromPrice = 0,int ToPrice=0)
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = limit;
           var Users_Id = (int)ProjectSession.Users_Id;
            var result = abstractProductServices.Product_All(pageParam, Search, 2, Cat_Id,Users_Id, Subcat_Id, FromPrice, ToPrice);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //[HttpPost]
        //public JsonResult Product_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,int Cat_Id = 0)
        //{
        //    {
        //        int totalRecord = 0;
        //        int filteredRecord = 0;

        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = requestModel.Start;
        //        pageParam.Limit = requestModel.Length;

        //        string search = Convert.ToString(requestModel.Search.Value);
        //        var response = abstractProductServices.Product_All(pageParam, search, 2,  Cat_Id);

        //        totalRecord = (int)response.TotalRecords;
        //        filteredRecord = (int)response.TotalRecords;

        //        return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
        //    }
        //}
        [HttpPost]
        public JsonResult Product_Upsert(HttpPostedFileBase files, Product Product)
        {
            if (Product.Product_Id > 0)
            {
                Product.Updatedby = 0;// ProjectSession.AdminId;
            }
            else
            {
                Product.Createdby = 0;// ProjectSession.AdminId;
            }
            if (files != null)
            {
                string basePath = "ProductImg/" + Product.Product_Id + "/";
                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + "_" + Path.GetFileName(files.FileName);
                string path = Server.MapPath("~/" + basePath);
                if (!Directory.Exists(Path.Combine(HttpContext.Server.MapPath("~/" + basePath))))
                {
                    Directory.CreateDirectory(HttpContext.Server.MapPath("~/" + basePath));
                }
                Product.Image = basePath + fileName;
                files.SaveAs(HttpContext.Server.MapPath("~/" + basePath + fileName));
            }
            var result = abstractProductServices.Product_Upsert(Product);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Product_ById(int Product_Id = 0)
        {
            int Users_Id = (int)ProjectSession.Users_Id;
            SuccessResult<AbstractProduct> successResult = abstractProductServices.Product_ById(Product_Id, Users_Id);
           
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Product_ActInAct(int Product_Id)
        {
            SuccessResult<AbstractProduct> admin = new SuccessResult<AbstractProduct>();

            try
            {
                int Updatedby = 0;// ProjectSession.AdminId;
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
            int DeletedBy = 1;//ProjectSession.AdminId;

            var result = abstractProductServices.Product_Delete(Product_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}