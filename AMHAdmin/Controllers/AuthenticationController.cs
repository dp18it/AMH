using AMH.Common;
using AMHAdmin.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMH.Entities.V1;
using AMH.Services.Contract;
using AMH.Entities.Contract;
using AMHAdmin.Infrastructure;
using System.IO;
using System.Web.Hosting;
using System.Data.SqlClient;
using System.Data;

namespace AMHAdmin.Controllers
{
    public class AuthenticationController : BaseController
    {
        #region Fields
        private readonly AbstractAdminServices abstractAdminServices;
        #endregion
        #region Ctor
        public AuthenticationController(AbstractAdminServices abstractAdminServices)
        {
            this.abstractAdminServices = abstractAdminServices;
        }
        #endregion

        #region Methods

        public ActionResult Signin()
        {
            return View();
        }
        [HttpGet]
        [ActionName(Actions.ChangePassword)]
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult ResetPassword(string aid = "MA==")
        {
            ViewBag.AID = ConvertTo.Base64Decode(aid);
            return View();
        }
        [HttpPost]
        public JsonResult Check_ResetLink()
        {
            bool model = true;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ResetPassword(string NewPassword, string ConfirmPassword, int Admin_Id = 0)
        {
            if (NewPassword != null && NewPassword != "" && ConfirmPassword != "" && ConfirmPassword != null)
            {
                try
                {
                    string updateAdmin = "Update Admin SET Password = '" + NewPassword + "', IsResetPassword = 1 where Admin_Id = " + Admin_Id + "";
                    SqlConnection con = new SqlConnection(Configurations.ConnectionString);
                    SqlCommand UpAdmin = new SqlCommand(updateAdmin, con);
                    con.Open();
                    UpAdmin.ExecuteNonQuery();
                    con.Close();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }

                catch (Exception ex)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult IsEmailIdExists(string Email)
        {
            if (Email != null && Email != "")
            {
                try
                {
                    SuccessResult<AbstractAdmin> model = new SuccessResult<AbstractAdmin>();

                    string var_sql = "select Admin_Id,FirstName,LastName from Admin where IsActive != 0 and Deletedby = 0 and Email = ('" + Email + "') ";

                    SqlConnection con = new SqlConnection(Configurations.ConnectionString);
                    SqlDataAdapter sda = new SqlDataAdapter(var_sql, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        // Send Reset password to the email
                        // ProjectSession.ResetEmail = Email;
                        var FullName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                        var welcome = "Reset Your Password";

                        var rid = ConvertTo.Base64Encode(dt.Rows[0]["Admin_Id"].ToString());

                        var Link = Configurations.ClientURL + "Authentication/ResetPassword?uid=" + rid;
                        EmailHelper.SendEmail(welcome, Email, FullName, "We have recieved your request to reset the password.", "", Link);

                        string updateAdmin = "Update Admin SET IsResetPassword = 0 where IsActive != 0 and DeletedBy = 0 and Email = '" + Email + "'";
                        SqlCommand UpAdmin = new SqlCommand(updateAdmin, con);
                        con.Open();
                        UpAdmin.ExecuteNonQuery();
                        con.Close();

                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
       
      
       
       

        public static bool SendEmail(string welcometext, string toEmail, string fullname, string message, string Password, string Link)
        {
            //string body = "";
            //if(welcometext == "Welcome to Nigarsa.")
            //{ 
            //    using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/CreateUser.html")))
            //    {
            //        body = reader.ReadToEnd();
            //    }
            //}
            //else
            //{
            //    using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/EmailTemplate.html")))
            //    {
            //        body = reader.ReadToEnd();
            //    }
            //    body = body.Replace("@message", message);
            //}


            //body = body.Replace("@Email", toEmail);
            //body = body.Replace("@Name", fullname);
            //body = body.Replace("@welcometext", welcometext);
            //body = body.Replace("@Password", Password);

            //bool reason = EmailHelper.Send(toEmail, "", "", fullname, body);
            //return reason;


            string body = "";
            using (StreamReader reader = new StreamReader(HostingEnvironment.MapPath("~/EmailTemplate/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("@message", message);
            body = body.Replace("@Email", toEmail);
            body = body.Replace("@Name", fullname);
            body = body.Replace("@welcometext", welcometext);
            //body = body.Replace("@Password", Password);
            body = body.Replace("@Link", Link);

            bool reason = EmailHelper.Send(toEmail, "", "", fullname, body);
            return reason;
        }
        [HttpPost]
        [ActionName(Actions.ChangePassword)]
        public ActionResult ChangePassword(int Id, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            SuccessResult<AbstractAdmin> result = abstractAdminServices.Admin_ChangePassword(Id, OldPassword, NewPassword, ConfirmPassword);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Signin(string Email, string Password)
        {
            SuccessResult<AbstractAdmin> result = abstractAdminServices.Admin_SignIn(Email, Password);
            if (result.Code == 200 && result.Item != null)
            {
                Session.Clear();
                ProjectSession.AdminId = result.Item.Admin_Id;
                ProjectSession.LoginAdminEmail = result.Item.Email;

                HttpCookie cookie = new HttpCookie("AdminLogin");
                cookie.Values.Add("Id", result.Item.Admin_Id.ToString());
                cookie.Values.Add("Email", result.Item.Email);

                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Signout()
        {
            var result = abstractAdminServices.Admin_SignOut();
            if (result == true)
            {
                if (Request.Cookies["AdminLogin"] != null)
                {
                    string[] myCookies = Request.Cookies.AllKeys;
                    foreach (string cookie in myCookies)
                    {
                        Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                    }
                }
            }


            Session.Clear();
            Session.Abandon();

            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return RedirectToAction(Actions.Signin, Pages.Controllers.Authentication);
        }


        #endregion
    }
}