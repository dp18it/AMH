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
    //public class AppointmentController : BaseController
    //{
    //    public readonly AbstractAppointmentServices abstractAppointmentServices;
    //    public readonly AbstractCustomerServices abstractCustomerServices;
    //    public readonly AbstractEmployeesServices abstractEmployeesServices;
    //    public readonly AbstractMasterAppointmentStatusServices abstractMasterAppointmentStatusServices;
        
    //    public AppointmentController(
    //        AbstractAppointmentServices abstractAppointmentServices,
    //        AbstractCustomerServices abstractCustomerServices,
    //        AbstractEmployeesServices abstractEmployeesServices,
    //        AbstractMasterAppointmentStatusServices abstractMasterAppointmentStatusServices
    //        )
            
    //    {
    //        this.abstractAppointmentServices = abstractAppointmentServices;
    //        this.abstractCustomerServices = abstractCustomerServices;
    //        this.abstractEmployeesServices = abstractEmployeesServices;
    //        this.abstractMasterAppointmentStatusServices = abstractMasterAppointmentStatusServices;
    //    }

    //    [ActionName(Actions.Index)]
    //    public ActionResult Index()
    //    {
    //        ViewBag.Customer_All = Customer_All();
    //        ViewBag.Employees_All = Employees_All();
    //        ViewBag.MasterAppointmentStatus_All = MasterAppointmentStatus_All();
    //        return View();
    //    }


    //    [HttpPost]
    //    public IList<SelectListItem> Customer_All()
    //    {
    //        List<SelectListItem> items = new List<SelectListItem>();

    //        PageParam pageParam = new PageParam();
    //        pageParam.Offset = 0;
    //        pageParam.Limit = 0;

    //        var result = abstractCustomerServices.Customer_All(pageParam, "");

    //        items.Add(new SelectListItem() { Text = "All", Value = "0" });
    //        foreach (var master in result.Values)
    //        {
    //            items.Add(new SelectListItem() { Text = master.CustomerName.ToString(), Value = Convert.ToString(master.Id) });
    //        }

    //        return items;
    //    }
    //    [HttpPost]
    //    public IList<SelectListItem> MasterAppointmentStatus_All()
    //    {
    //        List<SelectListItem> items = new List<SelectListItem>();

    //        PageParam pageParam = new PageParam();
    //        pageParam.Offset = 0;
    //        pageParam.Limit = 0;

    //        var result = abstractMasterAppointmentStatusServices.MasterAppointmentStatus_All(pageParam, "");

    //        items.Add(new SelectListItem() { Text = "All", Value = "0" });
    //        foreach (var master in result.Values)
    //        {
    //            items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
    //        }

    //        return items;
    //    }
        
    //    [HttpPost]
    //    public IList<SelectListItem> Employees_All()
    //    {
    //        List<SelectListItem> items = new List<SelectListItem>();

    //        PageParam pageParam = new PageParam();
    //        pageParam.Offset = 0;
    //        pageParam.Limit = 0;

    //        var result = abstractEmployeesServices.Employees_All(pageParam, "");

    //        items.Add(new SelectListItem() { Text = "All", Value = "0" });
    //        foreach (var master in result.Values)
    //        {
    //            items.Add(new SelectListItem() { Text = master.EmployeeName.ToString(), Value = Convert.ToString(master.Id) });
    //        }

    //        return items;
    //    }


    //    public JsonResult Appointment_All([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
    //    {
    //        {
    //            int totalRecord = 0;
    //            int filteredRecord = 0;

    //            PageParam pageParam = new PageParam();
    //            pageParam.Offset = requestModel.Start;
    //            pageParam.Limit = requestModel.Length;

    //            string search = Convert.ToString(requestModel.Search.Value);
    //            var response = abstractAppointmentServices.Appointment_All(pageParam, search);

    //            totalRecord = (int)response.TotalRecords;
    //            filteredRecord = (int)response.TotalRecords;

    //            return Json(new DataTablesResponse(requestModel.Draw, response.Values, filteredRecord, totalRecord), JsonRequestBehavior.AllowGet);
    //        }
    //    }


    //    [HttpPost]
    //    public JsonResult AppointmentGET_All()
    //    {

    //        PageParam pageparam = new PageParam();
    //        pageparam.Offset = 0;
    //        pageparam.Limit = 0;    

    //        var result = abstractAppointmentServices.Appointment_All(pageparam,"");
    //        return Json(result, JsonRequestBehavior.AllowGet);
    //    }

    //    [HttpPost]
    //    public JsonResult Appointment_Upsert(Appointment Appointment)
    //    {
    //        if (Appointment.Id > 0)
    //        {
    //            Appointment.UpdatedBy = ProjectSession.AdminId;
    //        }
    //        else
    //        {
    //            //var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    //            //var stringChars = new char[8];
    //            //var random = new Random();

    //            //for (int i = 0; i < stringChars.Length; i++)
    //            //{
    //            //    stringChars[i] = chars[random.Next(chars.Length)];
    //            //}

    //            Appointment.CreatedBy = ProjectSession.AdminId;
    //        }

    //        var result = abstractAppointmentServices.Appointment_Upsert(Appointment);
    //        //if (result != null && result.Code == 200)
    //        //{
    //        //    if (Appointment.Id > 0)
    //        //    {
    //        //        // Update
    //        //        var welcome = "Greetings From Ginny Buddy.";
    //        //        EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "Email : " + result.Item.Email + " , Password : " + result.Item.Password + " Information Updated", result.Item.Password);

    //        //    }
    //        //    else
    //        //    {
    //        //        // Create
    //        //        var welcome = "Welcome to Ginny Buddy.";
    //        //        EmailHelper.SendEmail(welcome, result.Item.Email, result.Item.Name, "", result.Item.Password);
    //        //    }
    //        //}
    //        return Json(result, JsonRequestBehavior.AllowGet);
    //    }
        
    //    [HttpPost]
    //    public JsonResult Appointment_ById(string SMId = "MA==")
    //    {
    //        long Id = Convert.ToInt64(ConvertTo.Base64Decode(SMId));
    //        SuccessResult<AbstractAppointment> successResult = abstractAppointmentServices.Appointment_ById(Id);
    //        return Json(successResult, JsonRequestBehavior.AllowGet);
    //    }


    //    [HttpPost]
    //    public JsonResult Appointment_StatusChange(long Id,long Status)
    //    {
    //        SuccessResult<AbstractAppointment> admin = new SuccessResult<AbstractAppointment>();

    //        try
    //        {
    //            admin = abstractAppointmentServices.Appointment_StatusChange(Id,Status);
    //        }
    //        catch (Exception ex)
    //        {
    //            admin.Code = 400;
    //            admin.Message = ex.Message;
    //        }
    //        admin.Item = null;
    //        return Json(admin, JsonRequestBehavior.AllowGet);
    //    }
        
    //    [HttpPost]
    //    public JsonResult Appointment_ChangeDate(long Id,string AppointmentDate )
    //    {
    //        SuccessResult<AbstractAppointment> admin = new SuccessResult<AbstractAppointment>();

    //        try
    //        {
    //            admin = abstractAppointmentServices.Appointment_ChangeDate(Id,AppointmentDate);
    //        }
    //        catch (Exception ex)
    //        {
    //            admin.Code = 400;
    //            admin.Message = ex.Message;
    //        }
    //        admin.Item = null;
    //        return Json(admin, JsonRequestBehavior.AllowGet);
    //    }


    //    [HttpPost]
    //    public JsonResult Appointment_Delete(long Id)
    //    {
    //        long DeletedBy = ProjectSession.AdminId;

    //        var result = abstractAppointmentServices.Appointment_Delete(Id, DeletedBy);

    //        return Json(result, JsonRequestBehavior.AllowGet);
    //    }
    //}
}