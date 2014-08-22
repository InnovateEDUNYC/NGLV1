using System.Web.Mvc;
using System.Web.Routing;

namespace NGL.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Student Profile",
                url: "Student/{usi}",
                defaults: new {controller = "Student", action = "Index"},
                constraints: new { usi = @"\d+" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Edit Grades",
                url: "ParentCourse/Grades/{id}/Edit",
                defaults: new {controller = "ParentCourse", action = "EditGrades"},
                constraints: new {id = @"\d+"}
                );
        }
    }
}
