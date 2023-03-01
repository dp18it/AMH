//using AMH.Common;
//using AMH.Common.Paging;
//using AMH.Entities.Contract;
//using AMH.Services.Contract;
//using AMH.Infrastructure;
//using AMH.Pages;
//using DataTables.Mvc;
//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.Web;
//using System.Web.Mvc;
//using AMH.Entities.V1;
//using System.Web.Mail;
//using System.Net.Mail;

//    namespace SendMail.Controllers
//    {
//   public class MyaccountController : BaseController

//    { 
//        public ActionResult ForgotPassword()
//        {
//            //ViewBag.CityAll = CityDropDown();
//            // ViewBag.StateAll = StateDropDown();
//            return View();
//        }
//        //[HttpPost]
//        //public ActionResult ForgotPassword(string UserName)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        if (WebSecurity.UserExists(UserName))
//        //        {
//        //            string To = UserName, UserID, Password, SMTPPort, Host;
//        //            string token = WebSecurity.GeneratePasswordResetToken(UserName);
//        //            if (token == null)
//        //            {
//        //                // If user does not exist or is not confirmed.
//        //                return View("Index");
//        //            }
//        //            else
//        //            {
//        //                //Create URL with above token
//        //                var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = UserName, code = token }, "http") + "'>Reset Password</a>";
//        //                //HTML Template for Send email
//        //                string subject = "Your changed password";
//        //                string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;
//        //                //Get and set the AppSettings using configuration manager.
//        //                EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);
//        //                //Call send email methods.
//        //                EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);
//        //            }
//        //        }
//        //    }
//        //    return View();
//        //}
//        public ActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public ViewResult Index(SendMail.Models.MailModel _objModelMail)
//        {
//            if (ModelState.IsValid)
//            {
//                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
//                mail.To.Add(_objModelMail.To);
//                mail.From = new MailAddress(_objModelMail.From);
//                mail.Subject = _objModelMail.Subject;
//                string Body = _objModelMail.Body;
//                mail.Body = Body;
//                mail.IsBodyHtml = true;
//                SmtpClient smtp = new SmtpClient();
//                smtp.Host = "smtp.gmail.com";
//                smtp.Port = 587;
//                smtp.UseDefaultCredentials = false;
//                smtp.Credentials = new System.Net.NetworkCredential("username", "password"); // Enter seders User name and password       
//                smtp.EnableSsl = true;
//                smtp.Send(mail);
//                return View("Index", _objModelMail);
//            }
//            else
//            {
//                return View();
//            }
//        }
      

    
//}