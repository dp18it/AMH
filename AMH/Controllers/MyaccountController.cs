using AMH.Common;
using AMH.Common.Paging;
using AMH.Entities.Contract;
using AMH.Services.Contract;
using AMH.Infrastructure;
using AMH.Pages;
using DataTables.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AMH.Entities.V1;
using System.Data.SqlClient;
using System.Web.Hosting;
using System.Data;

namespace AMH.Controllers
{
    public class MyaccountController : BaseController
    {
        // GET: Wishlist
        private readonly AbstractUsersServices abstractUsersServices;
        private readonly AbstractCityServices abstractCityServices;
        private readonly AbstractStateServices abstractStateServices;
        private readonly AbstractOrderAMHServices abstractOrderAMHServices;



        public MyaccountController(AbstractUsersServices abstractUsersServices, AbstractCityServices abstractCityServices,
             AbstractStateServices abstractStateServices, AbstractOrderAMHServices abstractOrderAMHServices)
        {
            this.abstractUsersServices = abstractUsersServices;
            this.abstractCityServices = abstractCityServices;
            this.abstractStateServices = abstractStateServices;
            this.abstractOrderAMHServices = abstractOrderAMHServices;
        }
        public ActionResult Index(int add = 0)
        {
            ViewBag.isadd = add;
            ViewBag.CityAll = CityDropDown();
            ViewBag.StateAll = StateDropDown();
            if (ProjectSession.Users_Id == 0 || ProjectSession.Users_Id == null)
            {
                return RedirectToAction("Login", "Myaccount", new { area = "" });
            }
            else
            {
                return View();
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.CityAll = CityDropDown();
            ViewBag.StateAll = StateDropDown();
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult ResetPassword(string uid ="MA==")
        {
            ViewBag.UID = ConvertTo.Base64Decode(uid);
            return View();
        }
        [HttpPost]
        public JsonResult Check_ResetLink()
        {
            bool model = true;
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ResetPassword(string NewPassword, string ConfirmPassword, int User_Id = 0)
        {
            if (NewPassword != null && NewPassword != "" && ConfirmPassword != "" && ConfirmPassword != null)
            {
                try
                {
                    string updateUser = "Update Users SET Password = '" + NewPassword + "', IsResetPassword = 1 where Users_Id = " + User_Id + "";
                    SqlConnection con = new SqlConnection(Configurations.ConnectionString);
                    SqlCommand UpUser = new SqlCommand(updateUser, con);
                    con.Open();
                    UpUser.ExecuteNonQuery();
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

        //[HttpPost]
        //public JsonResult IsEmailIdExists(string Email)
        //{
        //    if (Email != null && Email != "")
        //    {
        //        try
        //        {
        //            SuccessResult<AbstractUsers> model = new SuccessResult<AbstractUsers>();

        //            string var_sql = "select Users_Id,FirstName,LastName from Users where IsActive != 0 and Deletedby = 0 and Email = ('" + Email + "') ";

        //            SqlConnection con = new SqlConnection(Configurations.ConnectionString);
        //            SqlDataAdapter sda = new SqlDataAdapter(var_sql, con);
        //            System.Data.DataTable dt = new System.Data.DataTable();
        //            sda.Fill(dt);

        //            if (dt.Rows.Count > 0)
        //            {
        //                // Send Reset password to the email
        //              //  ProjectSession.ResetEmail = Email;
        //                var FullName = dt.Rows[0]["FirstName"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
        //                var welcome = "Reset Your Password";

        //                var rid = ConvertTo.Base64Encode(dt.Rows[0]["Users_Id"].ToString());

        //                var Link = Configurations.ClientURL + "Account/ResetPassword/";
        //                //var Link = Configurations.ClientURL + "Account/ResetPassword/" + rid;
        //                EmailHelper.SendEmail(welcome, Email, FullName, "We have recieved your request to reset the password.", "", Link);

        //                string updatePatient = "Update Users SET IsResetPassword = 0 where Email = '" + Email + "'";
        //                SqlCommand UpPatient = new SqlCommand(updatePatient, con);
        //                con.Open();
        //                UpPatient.ExecuteNonQuery();
        //                con.Close();

        //                return Json(true, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                return Json(false, JsonRequestBehavior.AllowGet);
        //            }
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

        [HttpPost]
        public JsonResult IsEmailIdExists(string Email)
        {
            if (Email != null && Email != "")
            {
                try
                {
                    SuccessResult<AbstractUsers> model = new SuccessResult<AbstractUsers>();

                    string var_sql = "select Users_Id,FirstName,LastName from Users where IsActive != 0 and Deletedby = 0 and Email = ('" + Email + "') ";

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

                        var rid = ConvertTo.Base64Encode(dt.Rows[0]["Users_Id"].ToString());

                        var Link = Configurations.ClientURL + "Myaccount/ResetPassword?uid=" + rid;
                        EmailHelper.SendEmail(welcome, Email, FullName, "We have recieved your request to reset the password.", "", Link);

                        string updateUser = "Update Users SET IsResetPassword = 0 where IsActive != 0 and DeletedBy = 0 and Email = '" + Email + "'";
                        SqlCommand UpUser = new SqlCommand(updateUser, con);
                        con.Open();
                        UpUser.ExecuteNonQuery();
                        con.Close();

                        return Json(true, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception)
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
        //public ActionResult ForgotPassword()
        //{
        //    //ViewBag.CityAll = CityDropDown();
        //    // ViewBag.StateAll = StateDropDown();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ForgotPassword(string UserName)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (WebSecurity.UserExists(UserName))
        //        {
        //            string To = UserName, UserID, Password, SMTPPort, Host;
        //            string token = WebSecurity.GeneratePasswordResetToken(UserName);
        //            if (token == null)
        //            {
        //                // If user does not exist or is not confirmed.
        //                return View("Index");
        //            }
        //            else
        //            {
        //                //Create URL with above token
        //                var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = UserName, code = token }, "http") + "'>Reset Password</a>";
        //                //HTML Template for Send email
        //                string subject = "Your changed password";
        //                string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;
        //                //Get and set the AppSettings using configuration manager.
        //                EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);
        //                //Call send email methods.
        //                EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);
        //            }
        //        }
        //    }
        //    return View();
        //}
        public IList<SelectListItem> CityDropDown(int sid = 0)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                PageParam pageParam = new PageParam();
                pageParam.Offset = 0;
                pageParam.Limit = 0;

                var models = abstractCityServices.City_All(pageParam, "", sid);

                foreach (var master in models.Values)
                {
                    items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
                }

                return items;
            }
            catch (Exception ex)
            {
                return items;
            }
        }

        public IList<SelectListItem> StateDropDown()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            try
            {
                PageParam pageParam = new PageParam();
                pageParam.Offset = 0;
                pageParam.Limit = 0;

                var models = abstractStateServices.State_All(pageParam, "");

                foreach (var master in models.Values)
                {
                    items.Add(new SelectListItem() { Text = master.Name.ToString(), Value = Convert.ToString(master.Id) });
                }

                return items;
            }
            catch (Exception ex)
            {
                return items;
            }
        }
        [HttpPost]
        public JsonResult User_SignIn(string Email, string Password)
        {
            SuccessResult<AbstractUsers> result = abstractUsersServices.User_SignIn(Email, Password);
            if (result.Code == 200 && result.Item != null)
            {
                Session.Clear();
                ProjectSession.Users_Id = result.Item.Users_Id;
                ProjectSession.Email = result.Item.Email;

                HttpCookie cookie = new HttpCookie("UserLogin");
                cookie.Values.Add("Users_Id", result.Item.Users_Id.ToString());
                cookie.Values.Add("Email", result.Item.Email);

                cookie.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(cookie);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult User_SignOut()
        {
            var result = abstractUsersServices.User_SignOut();
            if (result == true)
            {
                if (Request.Cookies["UserLogin"] != null)
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
            return RedirectToAction(Actions.Index, Pages.Controllers.Home);
        }
        [HttpGet]
        [ActionName(Actions.ChangePassword)]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ActionName(Actions.ChangePassword)]
        public ActionResult ChangePassword(int Id, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            SuccessResult<AbstractUsers> result = abstractUsersServices.Users_ChangePassword(Id, OldPassword, NewPassword, ConfirmPassword);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Users_Upsert(HttpPostedFileBase files, Users Users)
        {
            if (Users.Users_Id > 0)
            {
                Users.BirthDate = null;
                Users.Updatedby = (int)ProjectSession.Users_Id;
            }
            if (files != null)
            {
                string basePath = "UsersProfile/";
                string fileName = DateTime.Now.ToString("ddMMyyyyhhmmss") + "_" + Path.GetFileName(files.FileName);
                if (!Directory.Exists(Path.Combine(HttpContext.Server.MapPath("~/" + basePath))))
                {
                    Directory.CreateDirectory(HttpContext.Server.MapPath("~/" + basePath));
                }
                Users.Image = basePath + fileName;
                files.SaveAs(HttpContext.Server.MapPath("~/" + basePath + fileName));
            }
            var result = abstractUsersServices.Users_Upsert(Users);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Users_ById(int Users_Id = 0)
        {
            SuccessResult<AbstractUsers> successResult = abstractUsersServices.Users_ById(Users_Id);
            return Json(successResult, JsonRequestBehavior.AllowGet);
        }
    }
}