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
    public class UsersController : BaseController
    {
        public readonly AbstractUsersServices abstractUsersServices;
        

        public UsersController(
           AbstractUsersServices abstractUsersServices)

        {
          this.abstractUsersServices = abstractUsersServices;
        
        }
        [ActionName(Actions.Index)]
        public ActionResult Index()
        {
            //ViewBag.SubCategoryDrp = SubCategoryDrp();
            return View();
        } 
        
        public JsonResult Users_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel
          ,int CityId=0,int StateId=0, string FromDate = "", string ToDate = "")
        {
            {
                int totalRecord = 0;
                int filteredRecord = 0;

                PageParam pageParam = new PageParam();
                pageParam.Offset = requestModel.Start;
                pageParam.Limit = requestModel.Length;

                string search = Convert.ToString(requestModel.Search.Value);
                var response = abstractUsersServices.Users_All(pageParam, search, CityId, StateId, 2, FromDate, ToDate);

                totalRecord = (int)response.TotalRecords;
                filteredRecord = (int)response.TotalRecords;

                return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult Users_Delete(int Users_Id)
        {
            int DeletedBy = (int)ProjectSession.AdminId;

            var result = abstractUsersServices.Users_Delete(Users_Id, DeletedBy);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Users_ActInact(int Users_Id)
        {
            SuccessResult<AbstractUsers> admin = new SuccessResult<AbstractUsers>();

            try
            {
                int Updatedby = (int)ProjectSession.AdminId;
                admin = abstractUsersServices.Users_ActInact(Users_Id, Updatedby);
            }
            catch (Exception ex)
            {
                admin.Code = 400;
                admin.Message = ex.Message;
            }
            admin.Item = null;
            return Json(admin, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult Users_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        //{
        //    {
        //        int totalRecord = 0;
        //        int filteredRecord = 0;

        //        PageParam pageParam = new PageParam();
        //        pageParam.Offset = requestModel.Start;
        //        pageParam.Limit = requestModel.Length;

        //        string search = Convert.ToString(requestModel.Search.Value);
        //        var response = abstractUsersServices.Users_All(pageParam, search);

        //        totalRecord = (int)response.TotalRecords;
        //        filteredRecord = (int)response.TotalRecords;

        //        return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public JsonResult Users_Upsert(Users Users)
        //{
        //    if (Users.Id > 0)
        //    {
        //        Users.UpdatedBy = ProjectSession.AdminId;
        //    }
        //    else
        //    {
        //        //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        //        //var stringChars = new char[8];
        //        //var random = new Random();

        //        //for (int i = 0; i < stringChars.Length; i++)
        //        //{
        //        //    stringChars[i] = chars[random.Next(chars.Length)];
        //        //}

        //        Users.CreatedBy = ProjectSession.AdminId;
        //    }

        //    var result = abstractUsersServices.Users_Upsert(Users);
        //    //if (result != null && result.Code == 200)
        //    //{
        //    //    if (Users.Id > 0)
        //    //    {
        //    //        // Update
        //    //        var welcome = "Greetings From Ginny Buddy.";
        //    //        EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "Email : " + result.Item.Email + " , Password : " + result.Item.Password + " Information Updated", result.Item.Password);

        //    //    }
        //    //    else
        //    //    {
        //    //        // Create
        //    //        var welcome = "Welcome to Ginny Buddy.";
        //    //        EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "", result.Item.Password);
        //    //    }
        //    //}
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        ////[HttpPost]
        ////public JsonResult Admin_Upsert(Admin admin)
        ////{
        ////    if (admin.Id > 0)
        ////    {
        ////        admin.UpdatedBy = ProjectSession.AdminId;
        ////    }
        ////    else
        ////    {
        ////        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        ////        var stringChars = new char[8];
        ////        var random = new Random();

        ////        for (int i = 0; i < stringChars.Length; i++)
        ////        {
        ////            stringChars[i] = chars[random.Next(chars.Length)];
        ////        }

        ////        admin.Password = new String(stringChars);
        ////        admin.CreatedBy = ProjectSession.AdminId;
        ////    }

        ////    var result = abstractAdminServices.Admin_Upsert(admin);
        ////    if (result != null && result.Code == 200)
        ////    {
        ////        if (admin.Id  > 0)
        ////        {
        ////            // Update
        ////            var welcome = "Greetings From Ginny Buddy.";
        ////            EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "Email : " + result.Item.Email + " , Password : " + result.Item.Password +  " Information Updated", result.Item.Password);

        ////        }
        ////        else
        ////        {
        ////            // Create
        ////            var welcome = "Welcome to Ginny Buddy.";
        ////            EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "", result.Item.Password);
        ////        }
        ////    }
        ////    else
        ////    {
        ////        throw new Exception(result.Message);
        ////    }

        ////    return Json(result, JsonRequestBehavior.AllowGet);
        ////}

        //[HttpPost]
        //public JsonResult Users_ById(string SMId = "MA==")
        //{
        //    long Id = Convert.ToInt64(ConvertTo.Base64Decode(SMId));
        //    SuccessResult<AbstractUsers> successResult = abstractUsersServices.Users_ById(Id);
        //    return Json(successResult, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public JsonResult Users_ActInAct(long Id)
        //{
        //    SuccessResult<AbstractUsers> admin = new SuccessResult<AbstractUsers>();

        //    try
        //    {
        //        admin = abstractUsersServices.Users_ActInAct(Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        admin.Code = 400;
        //        admin.Message = ex.Message;
        //    }
        //    admin.Item = null;
        //    return Json(admin, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public JsonResult Users_Delete(long Id)
        //{
        //    long DeletedBy = ProjectSession.AdminId;

        //    var result = abstractUsersServices.Users_Delete(Id, DeletedBy);

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}