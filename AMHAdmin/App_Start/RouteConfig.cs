using System.Web.Mvc;
using System.Web.Routing;


namespace AMHAdmin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "Signin", id = UrlParameter.Optional },
                namespaces: new[] { "AMHAdmin.Controllers" }
            );
        }
    }
}
