using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AMH.Pages;
using AMH.Infrastructure;
using AMH.Common;
using Autofac;
using System;
using System.Web.Configuration;
using Stripe;

namespace AMH
{
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            ModelMetadataProviders.Current = new CachedDataAnnotationsModelMetadataProvider();
            ContainerBuilder builder = new ContainerBuilder();

            var secretkey = WebConfigurationManager.AppSettings["StripeSecretKey"];
            StripeConfiguration.SetApiKey(secretkey);
            //     builder.RegisterType<BaseController>()
            //.As<BaseController>();

            Bootstrapper.Resolve(builder);
        }

        /// <summary>
        /// This method is called on application end request
        /// </summary>
        public void Application_EndRequest()
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Code that runs when an unhandled error occurs
            Exception ErrorInfo = Server.GetLastError().GetBaseException();
            CommonHelper.LogError(Server.MapPath("~/ErrorLog/ErrorLog.txt"), ErrorInfo);
            //Infrastructure.ErrorLogHelper.Log(ErrorInfo);
            //Server.ClearError();
            //Response.Redirect(ConfigItems.HostURL + Pages.Controllers.Account + "/" + Pages.Actions.Error);
        }
    }
}
