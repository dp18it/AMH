using AMH.Common;
using AMH.Entities.Contract;
using AMH.Entities.V1;
using AMH.Services.Contract;
using AMHAdmin.Pages;
using AMHAdmin.Infrastructure;
using System;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Web.Hosting;

namespace AMH.Controllers
{
    public class AccountController : BaseController
    {
        #region Fields
        private readonly AbstractAdminServices abstractAdminServices;
        #endregion

        #region Ctor
        public AccountController(AbstractAdminServices abstractAdminServices)
        {
            this.abstractAdminServices = abstractAdminServices;
        }
        
        [ActionName(Actions.Signin)]
        public ActionResult Signin()
        {
            return View();
        }
        
        //public ActionResult ForgotPassword()
        //{
        //    return View();
        //}
        //public ActionResult ResetPassword(string uid = "MA==")
        //{
        //    ViewBag.UID = ConvertTo.Base64Decode(uid);
        //    return View();
        //}
        //[HttpPost]
        //public JsonResult Check_ResetLink()
        //{
        //    bool model = true;
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}
        //[HttpPost]
        //public JsonResult ResetPassword(string NewPassword, string ConfirmPassword, int Admin_Id = 0)
        //{
        //    if (NewPassword != null && NewPassword != "" && ConfirmPassword != "" && ConfirmPassword != null)
        //    {
        //        try
        //        {
        //            string updateAdmin = "Update Admin SET Password = '" + NewPassword + "', IsResetPassword = 1 where Admin_Id = " + Admin_Id + "";
        //            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
        //            SqlCommand UpUser = new SqlCommand(updateAdmin, con);
        //            con.Open();
        //            UpUser.ExecuteNonQuery();
        //            con.Close();
        //            return Json(true, JsonRequestBehavior.AllowGet);
        //        }

        //        catch (Exception ex)
        //        {
        //            return Json(false, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[HttpPost]
        //public JsonResult IsEmailIdExists(string Email)
        //{
        //    if (Email != null && Email != "")
        //    {
        //        try
        //        {
        //            SuccessResult<AbstractAdmin> model = new SuccessResult<AbstractAdmin>();

        //            string var_sql = "select Admin_Id,FirstName,LastnName from Admin where IsActive != 0 and Deletedby = 0 and Email = ('" + Email + "') ";

        //            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
        //            SqlDataAdapter sda = new SqlDataAdapter(var_sql, con);
        //            DataTable dt = new DataTable();
        //            sda.Fill(dt);

        //            if (dt.Rows.Count > 0)
        //            {
        //                // Send Reset password to the email
        //                // ProjectSession.ResetEmail = Email;
        //                var FullName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
        //                var welcome = "Reset Your Password";

        //                var rid = ConvertTo.Base64Encode(dt.Rows[0]["Users_Id"].ToString());

        //                var Link = Configurations.ClientURL + "Acount/ResetPassword?uid=" + rid;
        //                EmailHelper.SendEmail(welcome, Email, FullName, "We have recieved your request to reset the password.", "", Link);

        //                string updateUser = "Update Admin SET IsResetPassword = 0 where IsActive != 0 and DeletedBy = 0 and Email = '" + Email + "'";
        //                SqlCommand UpUser = new SqlCommand(updateUser, con);
        //                con.Open();
        //                UpUser.ExecuteNonQuery();
        //                con.Close();

        //                return Json(true, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                return Json(false, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return Json(false, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public static bool SendEmail(string welcometext, string toEmail, string fullname, string message, string Password, string Link)
        //{
        //    //string body = "";
        //    //if(welcometext == "Welcome to Nigarsa.")
        //    //{ 
        //    //    using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/CreateUser.html")))
        //    //    {
        //    //        body = reader.ReadToEnd();
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/EmailTemplate.html")))
        //    //    {
        //    //        body = reader.ReadToEnd();
        //    //    }
        //    //    body = body.Replace("@message", message);
        //    //}


        //    //body = body.Replace("@Email", toEmail);
        //    //body = body.Replace("@Name", fullname);
        //    //body = body.Replace("@welcometext", welcometext);
        //    //body = body.Replace("@Password", Password);

        //    //bool reason = EmailHelper.Send(toEmail, "", "", fullname, body);
        //    //return reason;


        //    string body = "";
        //    using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/EmailTemplate.html")))
        //    {
        //        body = reader.ReadToEnd();
        //    }
        //    body = body.Replace("@message", message);
        //    body = body.Replace("@Email", toEmail);
        //    body = body.Replace("@Name", fullname);
        //    body = body.Replace("@welcometext", welcometext);
        //    //body = body.Replace("@Password", Password);
        //    body = body.Replace("@Link", Link);

        //    bool reason = EmailHelper.Send(toEmail, "", "", fullname, body);
        //    return reason;
        //}
       

        public JsonResult UnAuthorizedAccess()
        {
            return Json(new { Code = 401,Message= "Unauthorized Access" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}