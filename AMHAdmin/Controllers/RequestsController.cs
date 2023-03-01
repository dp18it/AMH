//using AMH.Common;
//using AMH.Common.Paging;
//using AMH.Entities.V1;
//using AMH.Services.Contract;
//using AMHAdmin.Infrastructure;
//using AMHAdmin.Pages;
//using DataTables.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Web.Mvc;

//namespace AMHAdmin.Controllers
//{
//    public class RequestsController : BaseController
//    {
//        //private readonly AbstractRequestsServices abstractRequestsServices = null;
//        //private readonly AbstractUsersServices abstractUsersServices = null;
//        //private readonly AbstractDeliveryExecutiveServices abstractDeliveryExecutiveServices = null;
//        //private readonly AbstractServiceMasterServices abstractServiceMasterServices = null;
//        //private readonly AbstractSubServiceMasterServices abstractSubServiceMasterServices = null;
//        //private readonly AbstractLookupStatusServices abstractLookupStatusServices = null;
//        //private readonly AbstractRequestsDelieveryExecutiveTrackerServices abstractRequestsDelieveryExecutiveTrackerServices = null;
//        //private readonly AbstractRequestsStatusTrackerServices abstractRequestsStatusTrackerServices = null;
//        //private readonly AbstractUserNotificationsServices abstractUserNotificationsServices = null;
//        //private readonly AbstractDeliveryExecutiveNotificationsServices abstractDeliveryExecutiveNotificationsServices = null;
//        //private readonly AbstractRequestDocumentsServices abstractRequestDocumentsServices = null;


//        //public RequestsController(AbstractRequestsServices abstractRequestsServices,
//        //    AbstractUsersServices abstractUsersServices,
//        //    AbstractDeliveryExecutiveServices abstractDeliveryExecutiveServices,
//        //    AbstractServiceMasterServices abstractServiceMasterServices,
//        //    AbstractSubServiceMasterServices abstractSubServiceMasterServices,
//        //    AbstractLookupStatusServices abstractLookupStatusServices,
//        //    AbstractRequestsDelieveryExecutiveTrackerServices abstractRequestsDelieveryExecutiveTrackerServices,
//        //    AbstractRequestsStatusTrackerServices abstractRequestsStatusTrackerServices,
//        //    AbstractUserNotificationsServices abstractUserNotificationsServices,
//        //    AbstractDeliveryExecutiveNotificationsServices abstractDeliveryExecutiveNotificationsServices,
//        //    AbstractRequestDocumentsServices abstractRequestDocumentsServices
//            //)
//       //{
//       //      this.abstractRequestsServices = abstractRequestsServices;
//       //     this.abstractUsersServices = abstractUsersServices;
//       //     this.abstractDeliveryExecutiveServices = abstractDeliveryExecutiveServices;
//       //     this.abstractServiceMasterServices = abstractServiceMasterServices;
//       //     this.abstractSubServiceMasterServices = abstractSubServiceMasterServices;
//       //     this.abstractLookupStatusServices = abstractLookupStatusServices;
//       //     this.abstractRequestsDelieveryExecutiveTrackerServices = abstractRequestsDelieveryExecutiveTrackerServices;
//       //     this.abstractRequestsStatusTrackerServices = abstractRequestsStatusTrackerServices;
//       //     this.abstractUserNotificationsServices = abstractUserNotificationsServices;
//       //     this.abstractDeliveryExecutiveNotificationsServices = abstractDeliveryExecutiveNotificationsServices;
//       //     this.abstractRequestDocumentsServices = abstractRequestDocumentsServices;
           
            
//       // }

//        [ActionName(Actions.Index)]
//        public ActionResult Index(string DEId = "MA==", string UId = "MA==")
//        {
//            ViewBag.DEid = Convert.ToInt64(ConvertTo.Base64Decode(DEId));
//            ViewBag.Uid = Convert.ToInt64(ConvertTo.Base64Decode(UId));
//            ViewBag.GetUsersAll = GetUsers_All();
//            ViewBag.GetDeliveryExecutiveAll = GetDE_All();
//            ViewBag.GetServiceMasterAll = GetService_All();
//            ViewBag.GetStatusAll = GetLookStatus_All();

//            return View();
//        }

//        [ActionName(Actions.Details)]
//        public ActionResult Details(string RId = "MA==")
//        {
//            ViewBag.Rid = RId;
//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 100;
//            ViewBag.GetDeliveryExecutiveAll = GetDEA_All(RId);
//            ViewBag.RequestDocuments = abstractRequestDocumentsServices.RequestDocuments_ByRequestId(pageParam, Convert.ToInt64(ConvertTo.Base64Decode(RId))).Values;
//            return View();
//        }

//        [HttpPost]
//        public ActionResult GetRequest_ById(string RID)
//        {

//            long Rid = Convert.ToInt64(ConvertTo.Base64Decode(RID));
//            var result = abstractRequestsServices.Requests_ById(Rid);

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [HttpPost]
//        public ActionResult GetRequestDETracker_ByRId(string RID)
//        {
//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            long Rid = Convert.ToInt64(ConvertTo.Base64Decode(RID));
//            var result = abstractRequestsDelieveryExecutiveTrackerServices.RequestsDelieveryExecutiveTracker_ByRequestId(pageParam, "", Rid);

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [HttpPost]
//        public ActionResult GetRequestStatusTracker_ByRId(string RID)
//        {
//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            long Rid = Convert.ToInt64(ConvertTo.Base64Decode(RID));
//            var result = abstractRequestsStatusTrackerServices.RequestsStatusTracker_ByRequestId(pageParam, "", Rid);

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [HttpPost]
//        public ActionResult GetUserNotification_ByRId(string RID, long UserId)
//        {
//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            long Rid = Convert.ToInt64(ConvertTo.Base64Decode(RID));
//            var result = abstractUserNotificationsServices.UserNotifications_ByRequestId(pageParam, Rid, UserId);

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [HttpPost]
//        public ActionResult GetDENotificaiton_ByRId(string RID)
//        {
//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            long Rid = Convert.ToInt64(ConvertTo.Base64Decode(RID));
//            var result = abstractDeliveryExecutiveNotificationsServices.DeliveryExecutiveNotifications_ByRequestId(pageParam, Rid);

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public JsonResult ViewRequestAllData([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,
//            long UserId = 0, long DeliveryExecutiveId = 0, long ServiceMasterId = 0, long SubServiceMasterId = 0,
//            long StatusId = 0)
//        {
//            {
//                int totalRecord = 0;
//                int filteredRecord = 0;

//                PageParam pageParam = new PageParam();
//                pageParam.Offset = requestModel.Start;
//                pageParam.Limit = requestModel.Length;
//                string search = Convert.ToString(requestModel.Search.Value);

//                var response = abstractRequestsServices.Requests_All(pageParam, search,
//                UserId, DeliveryExecutiveId, ServiceMasterId, SubServiceMasterId, StatusId);

//                totalRecord = (int)response.TotalRecords;
//                filteredRecord = (int)response.TotalRecords;

//                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
//            }
//        }

//        [HttpPost]
//        public IList<SelectListItem> GetUsers_All()
//        {
//            List<SelectListItem> items = new List<SelectListItem>();

//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            var result = abstractUsersServices.Users_All(pageParam, "", "", "", "", 0, 0);
//            items.Add(new SelectListItem() { Text = "All", Value = "0" });
//            foreach (var master in result.Values)
//            {
//                items.Add(new SelectListItem() { Text = master.FirstName.ToString() + ' ' +  master.LastName.ToString() + " - " + master.MobileNumber.ToString(), Value = Convert.ToString(master.Id) });
//            }

//            return items;
//        }

//        [HttpPost]
//        public IList<SelectListItem> GetDE_All()
//        {
//            List<SelectListItem> items = new List<SelectListItem>();

//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            var result = abstractDeliveryExecutiveServices.DeliveryExecutive_All(pageParam,"", "", "", 0, 0, 0, 0);
//            items.Add(new SelectListItem() { Text = "All", Value = "0" });
//            foreach (var master in result.Values)
//            {
//                items.Add(new SelectListItem() { Text = master.FirstName.ToString() + ' ' + master.LastName.ToString() + " - " + master.MobileNumber.ToString(), Value = Convert.ToString(master.Id) });
//            }

//            return items;
//        }

//        [HttpPost]
//        public IList<SelectListItem> GetService_All()
//        {
//            List<SelectListItem> items = new List<SelectListItem>();

//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            var result = abstractServiceMasterServices.ServiceMaster_All(pageParam, "");
//            items.Add(new SelectListItem() { Text = "All", Value = "0" });
//            foreach (var master in result.Values)
//            {
//                items.Add(new SelectListItem() { Text = master.ServiceName.ToString(), Value = Convert.ToString(master.Id) });
//            }

//            return items;
//        }

//        [HttpPost]
//        public ActionResult GetSubService_All(long id)
//        {
//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            var result = abstractSubServiceMasterServices.SubServiceMaster_ByServiceMasterId(pageParam, "", id);

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [HttpPost]
//        public IList<SelectListItem> GetLookStatus_All()
//        {
//            List<SelectListItem> items = new List<SelectListItem>();

//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;

//            var result = abstractLookupStatusServices.LookupStatus_All(pageParam, "");

//            items.Add(new SelectListItem() { Text = "All", Value = "0" });
//            foreach (var master in result.Values)
//            {
//                items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
//            }

//            return items;
//        }

//        [HttpPost]
//        public JsonResult DeleteRequestDocuments(long RequestDocumentId)
//        {
//            long DeletedBy = ProjectSession.AdminId;

//            var result = abstractRequestDocumentsServices.RequestDocuments_Delete(RequestDocumentId, DeletedBy);

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        [HttpPost]
//        public IList<SelectListItem> GetDEA_All(string RID)
//        {
//            List<SelectListItem> items = new List<SelectListItem>();

//            PageParam pageParam = new PageParam();
//            pageParam.Offset = 0;
//            pageParam.Limit = 0;
//            long Rid = Convert.ToInt64(ConvertTo.Base64Decode(RID));
//            var result = abstractDeliveryExecutiveServices.Requests_NotAssignedDeliveryExecutive_All(pageParam,  Rid);
//            //items.Add(new SelectListItem() /*{ Text = "All", Value = "0" }*/);
//            foreach (var master in result.Values)
//            {
//                items.Add(new SelectListItem() { Text = master.FirstName.ToString() + ' ' + master.LastName.ToString() + " - " + master.MobileNumber.ToString(), Value = Convert.ToString(master.Id) });
//            }

//            return items;
//        }
//        [HttpPost]
//        public JsonResult Requests_AssignDeliveryExecutive(Requests requests)
//        {
//            requests.AssignedBy = ProjectSession.AdminName;
//            requests.IsAssignedByAdmin = 1;

//            var result = abstractRequestsServices.Requests_AssignDeliveryExecutive(requests);
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }


//        [HttpPost]
//        public JsonResult Requests_UpdateEstimatedETA(DateTime EstimatedETA ,long Id = 0)      
//            {
//            Requests model = new Requests();
//            model.Id = Id;
//            model.EstimatedETA = EstimatedETA;
           

            
//            var result = abstractRequestsServices.Requests_UpdateEstimatedETA(Id , EstimatedETA);
//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//    }
//}