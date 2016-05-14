using System;
using System.Linq;
using System.Web.Mvc;
using BIG_Warrior_Software_Official_Webpage.Models;

namespace BIG_Warrior_Software_Official_Webpage.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/HomeEdit
        public ActionResult Index()
        {
            ViewData["Status"] = String.Empty;
            using (b3752Entities db = new b3752Entities())
            {
                ViewData["HomeData"] = ((from homeDb in db.Home
                                         orderby homeDb.ModifyingDate descending
                                         select homeDb.HomeText).FirstOrDefault() == null) ? string.Empty : (from homeDb in db.Home
                                                                                                             orderby homeDb.ModifyingDate descending
                                                                                                             select homeDb.HomeText).FirstOrDefault();

            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Submit()
        {
            string editor = Request.Form["editor"].ToString();
            using (b3752Entities db = new b3752Entities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                Models.Home home = new Models.Home { ID = Guid.NewGuid(), HomeText = editor, ModifyingDate = DateTime.Now };
                home = db.Home.Add(home);
                db.SaveChanges();
                if (home == null)
                {
                    return Redirect("/Admin/Home/Status/Error");
                }
                else
                {
                    return Redirect("/Admin/Home/Status/Success");
                }
            }
        }

        public ActionResult Status(string status)
        {
            if (status == "Error")
            {
                ViewData["Status"] = "<p>Hiba történt!</p>";
            }
            else if (status=="Success")
            {
                ViewData["Status"] = "<p>Sikeres feltöltés!</p>";
            }
            return View("/Admin/Home");
        }
    }
}