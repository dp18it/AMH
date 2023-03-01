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
    public class FeedbackController : BaseController
    {
        public readonly AbstractFeedbackServices abstractFeedbackServices;
        //public readonly AbstractProductServices abstractProductServices;
        //public readonly AbstractUsersServices abstractUsersServices;

        public FeedbackController(AbstractFeedbackServices abstractFeedbackServices
             /*AbstractProductServices abstractProductServices, AbstractUsersServices abstractUsersServices*/)
        {
            this.abstractFeedbackServices = abstractFeedbackServices;
            //this.abstractProductServices = abstractProductServices;
            //this.abstractUsersServices = abstractUsersServices;
        }

        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            //ViewBag.ProductDrp = ProductDrp();
            //ViewBag.UsersDrp = UsersDrp();
            return View();
        }
        //[HttpPost]
        //public IList<SelectListItem> ProductDrp()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;

        //    var result = abstractProductServices.Product_All(pageParam, "", 2, 0, 0,0,0,0);

        //    foreach (var master in result.Values)
        //    {
        //        items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Product_Id) });
        //    }

        //    return items;
        //}
        //[HttpPost]
        //public IList<SelectListItem> UsersDrp()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();

        //    PageParam pageParam = new PageParam();
        //    pageParam.Offset = 0;
        //    pageParam.Limit = 0;

        //    var result = abstractUsersServices.Users_All(pageParam, "", 0, 0, 2,"","");

        //    foreach (var master in result.Values)
        //    {
        //        items.Add(new SelectListItem() { Text = master.FirstName.ToString(), Value = Convert.ToString(master.Users_Id) });
        //    }

        //    return items;
        //}


        public JsonResult Feedback_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel
            , int user_id=0, int product_id=0, string FromDate = "", string ToDate = "")
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractFeedbackServices.Feedback_All(pageParam, search, user_id, product_id, FromDate, ToDate);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Feedback_Upsert(Feedback Feedback)
        {
            if (Feedback.Id > 0)
            {
                Feedback.Updatedby = (int)ProjectSession.AdminId;
            }
            else
            {
                Feedback.Updatedby = (int)ProjectSession.AdminId;
            }

            var result = abstractFeedbackServices.Feedback_Upsert(Feedback);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Feedback_ById(int Id = 0)
        {
            SuccessResult<AbstractFeedback> successResult = abstractFeedbackServices.Feedback_ById(Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Feedback_Delete(int Id)
        {
            int DeletedBy = (int)ProjectSession.AdminId;

            var result = abstractFeedbackServices.Feedback_Delete(Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}