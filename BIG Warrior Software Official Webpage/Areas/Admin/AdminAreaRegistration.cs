using System.Web.Mvc;

namespace BIG_Warrior_Software_Official_Webpage.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {controller="LogIn", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}