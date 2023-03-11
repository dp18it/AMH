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
    public class PaymentController : BaseController
    {
        public readonly AbstractPaymentServices abstractPaymentServices;
        public readonly AbstractUsersServices abstractUsersServices;

        public PaymentController( AbstractPaymentServices abstractPaymentServices,
             AbstractUsersServices abstractUsersServices)
        {
            this.abstractPaymentServices = abstractPaymentServices;
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

        public JsonResult Payment_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int User_Id = 0, string FromDate = "", string ToDate = "")
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractPaymentServices.Payment_All(pageParam, search, User_Id, FromDate, ToDate);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        
        //[HttpPost]
        //public JsonResult Payment_ById(int Id = 0)
        //{
        //    SuccessResult<AbstractPayment> successResult = abstractPaymentServices.Payment_ById(Id);
        //    return Json(successResult, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult Payment_ActInact(int Payment_Id)
        {
            SuccessResult<AbstractPayment> admin = new SuccessResult<AbstractPayment>();

            try
            {
                int Updatedby = (int)ProjectSession.AdminId;
                admin = abstractPaymentServices.Payment_ActInact(Payment_Id, Updatedby);
            }
            catch (Exception ex)
            {
                admin.Code = 400;
                admin.Message = ex.Message;
            }
            admin.Item = null;
            return Json(admin, JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public JsonResult Payment_Delete(int Id)
        //{
        //    int Deletedby = (int)ProjectSession.AdminId;

        //    var result = abstractPaymentServices.Payment_Delete(Id, Deletedby);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}