using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIG_Warrior_Software_Official_Webpage.Areas.Admin.ViewModels;
using BIG_Warrior_Software_Official_Webpage.Models;
using BIG_Warrior_Software_Official_Webpage.Securities;

namespace BIG_Warrior_Software_Official_Webpage.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        GuidViewModel viewModel = new GuidViewModel();
        public ActionResult Index()
        {
            if (Session["AdminID"] != null)
            {
                using (b3752Entities db = new b3752Entities())
                {
                    Models.Admins admin = db.Admins.Find(Guid.Parse(Session["AdminID"].ToString()));
                    if (admin!=null)
                        return View();
                    else
                        return Redirect("/Admin/LogIn");
                }
            }
            else
            {
                return Redirect("/Admin/LogIn");
            }
        }
    }
}