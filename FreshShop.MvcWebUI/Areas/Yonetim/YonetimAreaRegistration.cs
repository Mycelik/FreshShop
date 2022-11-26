using System.Web.Mvc;

namespace FreshShop.MvcWebUI.Areas.Yonetim
{
    public class YonetimAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Yonetim";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "panelGiris",
                "panel",
                new { controller = "User", action = "LogIn", id = UrlParameter.Optional },
                new string[] { "FreshShop.MvcWebUI.Areas.Yonetim.Controllers" }
            );



            context.MapRoute(
                "Yonetim_default",
                "Yonetim/{controller}/{action}/{id}",
                new {controller= "User", action = "LogIn", id = UrlParameter.Optional },
                new string[] { "FreshShop.MvcWebUI.Areas.Yonetim.Controllers" }
            );
        }
    }
}