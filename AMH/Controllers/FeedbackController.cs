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
    public class FeedbackController : BaseController
    {

        public readonly AbstractFeedbackServices abstractFeedbackServices;

        public FeedbackController(AbstractFeedbackServices abstractFeedbackServices)
        {
            this.abstractFeedbackServices = abstractFeedbackServices;
        }
        public ActionResult Index(int Cat_Id = 0,string srech = "")
        {
            ViewBag.srech = srech;
            ViewBag.Cat_Id = Cat_Id;
            return View();
        }
        [HttpGet]
        [ActionName(Actions.Feedback_All)]
        public ActionResult Feedback_All( int Product_Id = 0,string FromDate="",string ToDate="")
        {
            PageParam pageParam = new PageParam();
            pageParam.Offset = 0;
            pageParam.Limit = 0;
           var Users_Id = (int)ProjectSession.Users_Id;
            var result = abstractFeedbackServices.Feedback_All(pageParam, "",Users_Id,Product_Id,FromDate,ToDate);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Feedback_Upsert(Feedback feedback,int I=0,string F="", int P=0)
        {
            feedback.Id = I;
            feedback.FeedBack = F;
            feedback.Product_Id = P;
            feedback.User_Id = (int)ProjectSession.Users_Id;
            if (feedback.Id > 0)
            {
                feedback.Updatedby =(int) ProjectSession.Users_Id;
            }
          
            var result = abstractFeedbackServices.Feedback_Upsert(feedback);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Feedback_ById(int Feedback_Id = 0)
        {
            int Users_Id = (int)ProjectSession.Users_Id;
            SuccessResult<AbstractFeedback> successResult = abstractFeedbackServices.Feedback_ById(Feedback_Id);
           
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }

     
        [HttpPost]
        public JsonResult Feedback_Delete(int Feedback_Id)
        {
            int DeletedBy = 1;//ProjectSession.AdminId;

            var result = abstractFeedbackServices.Feedback_Delete(Feedback_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}