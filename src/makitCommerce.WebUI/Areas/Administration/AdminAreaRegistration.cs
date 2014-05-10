namespace makit.makitCommerce.WebUI.Areas.Administration
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Administration"; }
        }

        public override void RegisterArea(
            AreaRegistrationContext context)
        {

            context.MapRoute(
                "AdministrationHome",
                "Administration/{action}",
                new { controller = "AdminHome" });

            context.MapRoute(
                "Administration",
                "Administration/{controller}/{action}",
                new { controller = "AdminHome", action = "Index" });

        }
    }
}