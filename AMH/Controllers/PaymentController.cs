using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMH.Infrastructure;
using Stripe;

namespace AMH.Controllers
{
    public class PaymentController : BaseController
    {
        // GET: Wishlist
        public ActionResult Index(int amount =0)
        {
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["StripePublishableKey"];
            ViewBag.Amount = amount;
            return View();
        }

        [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            Stripe.StripeConfiguration.SetApiKey("pk_test_51Mg7gISAy68Ys4b2rNRS7Ph8Icc8DybqiEJIU2y3wDhQly6x6wwqNVreMtub9UBjkkkx66pL3kx2RiUikuKCfYli007fqbKNuE");
            Stripe.StripeConfiguration.ApiKey = "sk_test_51Mg7gISAy68Ys4b2NqrOrfwbIN1GCiSOwMViRV8rbNuzKxH58NYzrnztqM7Rza5SViTTyzxTvAdeObr9O1iervFQ00jU1FS5Yh";

            var myCharge = new Stripe.ChargeCreateOptions();
            // always set these properties
            myCharge.Amount = 1;
            myCharge.Currency = "inr";
            myCharge.ReceiptEmail = "agricpower1@gmail.com";
            myCharge.Description = "Sample Charge";
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);
            return View();
        }

    }
}