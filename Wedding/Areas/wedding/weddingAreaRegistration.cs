using System.Web.Mvc;

namespace Wedding.Areas.wedding
{
    public class weddingAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "wedding";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {

            //context.MapRoute(
            //    "wedding_default",
            //    "wedding/{controller}/{action}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional },
            //    new string[] { "Wedding.Areas.wedding.Controllers" }
            //);

            context.MapRouteLowercase(
                "TagName",
                "wedding/Tag/{tagName}",
                new { controller = "Tag", action = "Posts" },
                new string[] { "Wedding.Areas.wedding.Controllers" }
                );

            context.MapRouteLowercase(
                "wedding_default",
                "wedding/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "Wedding.Areas.wedding.Controllers" }
            );


            //routes.MapRouteLowercase(
            //    "Default", // Route name
            //    "wedding/{controller}/{action}/{id}", // URL with parameters
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
            //    new string[] { "Wedding.Areas.wedding.Controllers" }
            //);
        }
    }
}
