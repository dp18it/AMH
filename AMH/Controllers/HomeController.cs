using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMH.Infrastructure;
using Stripe.Checkout;

namespace AMH.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCheckoutSession(string amount)
        {
            var options = new Stripe.Checkout.SessionCreateOptions
            {
                LineItems = new List <SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = Convert.ToInt32(amount) * 100,
                        Currency = "inr",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "AgricPower1",
                        },

                    },
                    Quantity = 1,
                },
        },
                Mode = "payment",
                SuccessUrl = "https://localhost:44354/Home/success",
                CancelUrl = "https://localhost:44354/Home/cancel",
            };

        var service = new Stripe.Checkout.SessionService();
        Stripe.Checkout.Session session = service.Create(options);

        Response.Headers.Add("Location", session.Url);
            //return new HttpStatusCodeResult(303);
            return Json(session, JsonRequestBehavior.AllowGet);
    }
        public ActionResult success()
        {
            return View();
        }
        public ActionResult cancel()
        {
            return View();
        }
    }
}