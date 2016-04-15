using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using BIG_Warrior_Software_Official_Webpage.Securities;
using BIG_Warrior_Software_Official_Webpage.Areas.Admin.ViewModels;
using BIG_Warrior_Software_Official_Webpage.Models;

namespace BIG_Warrior_Software_Official_Webpage.Areas.Admin.Controllers
{
    public class LogInController : Controller
    {
        GuidViewModel viewModel = new GuidViewModel();
        public ActionResult Index()
        {
            Session["Guid"] = viewModel.CRN;
            return View();
        }

        public ActionResult Run()
        {
            string username = Request.Form["usx"];
            string password = SecurityPassword.CreateMD5Hash(Request.Form["passx"]);
            string guid = Request.Form["guid"];
            if (guid == viewModel.CRN)
            {
                using (b3752Entities db = new b3752Entities())
                {
                    Guid ID = (from admins in db.Admins
                                         where admins.Username == username
                                         select admins.ID).Single();
                    Models.Admin admin = (from admins in db.Admins
                                          where admins.ID == ID
                                          && admins.Password == password
                                          select admins).Single();
                    if (admin == null)
                    {
                        return Redirect("/Admin/LogIn");
                    }
                    else
                    {
                        Session["AdminID"] = admin.ID;
                        return Redirect("/Admin/Dashboard");
                    }
                }
            }
            else
            {
                return Redirect("/Admin/LogIn");
            }
        }
    }
}