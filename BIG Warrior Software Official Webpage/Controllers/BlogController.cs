using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using BIG_Warrior_Software_Official_Webpage.Models;

namespace BIG_Warrior_Software_Official_Webpage.Controllers
{
    public class BlogController : Controller
    {
        [HttpGet]
        public ActionResult Index(int page = 1, int pageSize = 3)
        {
            int total = GetTotal();
            int currentPage = page;
            int skip = pageSize * (page - 1);
            bool canPage = skip < total;
            List<BlogEntry> blogEntries = GetBlog(pageSize, skip);
            StringBuilder sb = new StringBuilder();
            foreach (BlogEntry blogEntry in blogEntries)
            {
                sb.AppendLine("<article class=\"TopContent-Blog\">");
                sb.AppendLine("<header>");
                sb.AppendLine("<h2>"); sb.Append("<a href=\"/Blog/GetUrl/"); sb.Append(blogEntry.Url); sb.Append("\" title=\""); sb.Append(blogEntry.Title); sb.Append("\">"); sb.Append(blogEntry.Title); sb.Append("</a>"); sb.Append("</h2>");
                sb.AppendLine("</header>");
                sb.AppendLine("<footer>");
                sb.AppendLine("<p class=\"Post-Info\">Ezt a blogot "); sb.Append(blogEntry.AdminName); sb.Append(" írta "); sb.Append(blogEntry.CreationDate); sb.Append("-kor");
                if (!String.IsNullOrEmpty(blogEntry.ModifyingDate.ToString())) { sb.Append(" Módosítás dátuma: "); sb.Append(blogEntry.ModifyingDate.ToString()); }
                sb.Append("</p>");
                sb.AppendLine("<p class=\"Post-Info-Tags\">Címkék: ");
                foreach (Tags tag in blogEntry.TagsList)
                {
                    sb.Append("<a href=\"/Blog/TagName/");
                    sb.Append(tag.Name);

                    sb.Append("\">");
                    sb.Append(tag.Name);
                    sb.Append("</a>    ");
                }
                sb.Append("</p>");
                sb.AppendLine("</footer>");
                sb.AppendLine("<div class=\"BlogContent\">");
                sb.AppendLine(blogEntry.Body);
                sb.AppendLine("</div>");
                sb.AppendLine("</article>");
            }
            ViewData["BlogData"] = sb.ToString();
            sb.Clear();
            sb.AppendLine("<fieldset class=\"Pagination\">");
            sb.AppendLine("<legend>Oldalak</legend>");
            double result = (double)total / (double)pageSize;
            int pages = Convert.ToInt32(Math.Ceiling(result));
            for (int i = 1; i <= pages; i++)
            {
                if (i == currentPage)
                {
                    sb.Append("<span>");
                    sb.Append(i.ToString());
                    sb.Append("</span>");
                }
                else
                {
                    sb.Append("<a href=\"/Blog/Page/");
                    sb.Append(i.ToString());
                    sb.Append("\">");
                    sb.Append(i.ToString());
                    sb.Append("</a>");
                }
            }
            sb.AppendLine("</fieldset>");
            ViewData["Pagination"] = sb.ToString();
            return View();
        }

        [HttpGet]
        public ActionResult Page(int page = 1, int pageSize = 3)
        {
            int total = GetTotal();
            int currentPage = page;
            int skip = pageSize * (page - 1);
            bool canPage = skip < total;
            StringBuilder sb = new StringBuilder();
            List<BlogEntry> blogEntries = GetBlogByPageNumber(skip, pageSize);
            foreach (BlogEntry blogEntry in blogEntries)
            {
                sb.AppendLine("<article class=\"TopContent-Blog\">");
                sb.AppendLine("<header>");
                sb.AppendLine("<h2>"); sb.Append("<a href=\"/Blog/GetUrl/"); sb.Append(blogEntry.Url); sb.Append("\" title=\""); sb.Append(blogEntry.Title); sb.Append("\">"); sb.Append(blogEntry.Title); sb.Append("</a>"); sb.Append("</h2>");
                sb.AppendLine("</header>");
                sb.AppendLine("<footer>");
                sb.AppendLine("<p class=\"Post-Info\">Ezt a blogot "); sb.Append(blogEntry.AdminName); sb.Append(" írta "); sb.Append(blogEntry.CreationDate); sb.Append("-kor");
                if (!String.IsNullOrEmpty(blogEntry.ModifyingDate.ToString())) { sb.Append(" Módosítás dátuma: "); sb.Append(blogEntry.ModifyingDate.ToString()); }
                sb.Append("</p>");
                sb.AppendLine("<p class=\"Post-Info-Tags\">Címkék: ");
                foreach (Tags tag in blogEntry.TagsList)
                {
                    sb.Append("<a href=\"/Blog/TagName/");
                    sb.Append(tag.Name);

                    sb.Append("\">");
                    sb.Append(tag.Name);
                    sb.Append("</a>    ");
                }
                sb.Append("</p>");
                sb.AppendLine("</footer>");
                sb.AppendLine("<div class=\"BlogContent\">");
                sb.AppendLine(blogEntry.Body);
                sb.AppendLine("</div>");
                sb.AppendLine("</article>");
            }
            ViewData["BlogData"] = sb.ToString();
            sb.Clear();
            sb.AppendLine("<fieldset class=\"Pagination\">");
            sb.AppendLine("<legend>Oldalak</legend>");
            double result = (double)total / (double)pageSize;
            int pages = Convert.ToInt32(Math.Ceiling(result));
            for (int i = 1; i <= pages; i++)
            {
                if (i == currentPage)
                {
                    sb.Append("<span>");
                    sb.Append(i.ToString());
                    sb.Append("</span>");
                }
                else
                {
                    sb.Append("<a href=\"/Blog/Page/");
                    sb.Append(i.ToString());
                    sb.Append("\">");
                    sb.Append(i.ToString());
                    sb.Append("</a>");
                }
            }
            sb.AppendLine("</fieldset>");
            ViewData["Pagination"] = sb.ToString();
            return View("Index");
        }


        [HttpGet]
        public ActionResult GetUrl(string url)
        {
            BlogEntry blogEntry = GetBlogByUrl(url);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<article class=\"TopContent-Blog\">");
            sb.AppendLine("<header>");
            sb.AppendLine("<h2>"); sb.Append("<a href=\"/Blog/GetUrl/"); sb.Append(blogEntry.Url); sb.Append("\" title=\""); sb.Append(blogEntry.Title); sb.Append("\">"); sb.Append(blogEntry.Title); sb.Append("</a>"); sb.Append("</h1>");
            sb.AppendLine("</header");
            sb.AppendLine("<footer>");
            sb.AppendLine("<p class=\"Post-Info\">Ezt a blogot "); sb.Append(blogEntry.AdminName); sb.Append(" írta "); sb.Append(blogEntry.CreationDate); sb.Append("-kor");
            if (!String.IsNullOrEmpty(blogEntry.ModifyingDate.ToString())) { sb.AppendLine(" Módosítás dátuma: "); sb.Append(blogEntry.ModifyingDate.ToString()); }
            sb.Append("</p>");
            sb.AppendLine("<p class=\"Post-Info-Tags\">Címkék: ");
            foreach (Tags tag in blogEntry.TagsList)
            {
                sb.Append("<a href=\"/Blog/TagName/");
                sb.Append(tag.Name);

                sb.Append("\">");
                sb.Append(tag.Name);
                sb.Append("</a>    ");
            }
            sb.Append("</p>");
            sb.AppendLine("</footer>");
            sb.AppendLine(blogEntry.Body);
            sb.AppendLine("</article>");
            ViewData["BlogData"] = sb.ToString();
            ViewData["Pagination"] = null;
            return View("Index", blogEntry);
        }

        [HttpGet]
        public ActionResult TagName(string tag, int page = 1, int pageSize = 3)
        {
            int total = GetTotalByTagName(tag);
            int currentPage = page;
            int skip = pageSize * (page - 1);
            bool canPage = skip < total;

            List<BlogEntry> blogEntries = GetBlogsByTag(tag, skip, pageSize);
            StringBuilder sb = new StringBuilder();
            foreach (BlogEntry blogEntry in blogEntries)
            {
                sb.AppendLine("<article class=\"TopContent-Blog\">");
                sb.AppendLine("<header>");
                sb.AppendLine("<h1>"); sb.Append("<a href=\"/Blog/GetUrl/"); sb.Append(blogEntry.Url); sb.Append("\" title=\""); sb.Append(blogEntry.Title); sb.Append("\">"); sb.Append(blogEntry.Title); sb.Append("</a>"); sb.Append("</h1>");
                sb.AppendLine("</header>");
                sb.AppendLine("<footer>");
                sb.AppendLine("<p class=\"Post-Info\">Ezt a blogot "); sb.Append(blogEntry.AdminName); sb.Append(" írta "); sb.Append(blogEntry.CreationDate); sb.Append("-kor");
                if (!String.IsNullOrEmpty(blogEntry.ModifyingDate.ToString())) { sb.Append(" Módosítás dátuma: "); sb.Append(blogEntry.ModifyingDate.ToString()); }
                sb.Append("</p>");
                sb.AppendLine("<p class=\"Post-Info-Tags\">Címkék: ");
                foreach (Tags tagobj in blogEntry.TagsList)
                {
                    sb.Append("<a href=\"/Blog/TagName/");
                    sb.Append(tagobj.Name);

                    sb.Append("\">");
                    sb.Append(tagobj.Name);
                    sb.Append("</a>    ");
                }
                sb.Append("</p>");
                sb.AppendLine(blogEntry.Body);
                sb.AppendLine("</article>");
            }
            ViewData["BlogData"] = sb.ToString();
            sb.Clear();
            sb.AppendLine("<fieldset class=\"Pagination\">");
            sb.AppendLine("<legend>Oldalak</legend>");
            double result = (double)total / (double)pageSize;
            int pages = Convert.ToInt32(Math.Ceiling(result));
            for (int i = 1; i <= pages; i++)
            {
                if (i == currentPage)
                {
                    sb.AppendLine("<span>");
                    sb.Append(i.ToString());
                    sb.Append("</span>");
                }
                else
                {
                    sb.Append("<a href=\"/Blog/TagName/");
                    sb.Append(tag);
                    sb.Append("/");
                    sb.Append(i.ToString());
                    sb.Append("\">");
                    sb.Append(i.ToString());
                    sb.Append("</a>");
                }
            }
            sb.AppendLine("</fieldset>");
            ViewData["Pagination"] = sb.ToString();
            return View("Index");
        }

        private int GetTotalByTagName(string tag)
        {
            using (b3752Entities db = new b3752Entities())
            {
                db.Database.CommandTimeout = 5;
                db.Database.Connection.Open();
                int count = (from blogs in db.Blogs
                             let blogTags=blogs.BlogsTags
                             let tags=blogTags.Select(i=>i.Tags)
                             where blogs.BlogsTags.Any(i=>i.Tags.Name==tag)
                             select blogs).Count();
                db.Database.Connection.Close();
                return count;

                /*
                SELECT COUNT(blogs.ID)
                FROM 
                */
            }
        }

        private List<BlogEntry> GetBlogsByTag(string tag, int skip, int pageSize)
        {
            using (b3752Entities db = new b3752Entities())
            {

                db.Database.CommandTimeout = 5;
                db.Database.Log = Console.Write;
                db.Database.Connection.Open();
                IEnumerable<BlogEntry> blogEntries = (from blogs in db.Blogs
                                                      let admin = blogs.Admins
                                                      let blogsTags = blogs.BlogsTags
                                                      let tags = blogs.BlogsTags.Select(i => i.Tags)
                                                      where blogs.BlogsTags.Any(i => i.Tags.Name == tag)
                                                      orderby blogs.CreationDate descending
                                                      select new BlogEntry
                                                      {
                                                          ID = blogs.ID,
                                                          CreationDate = blogs.CreationDate,
                                                          ModifyingDate = blogs.ModifyingDate,
                                                          Url = blogs.Url,
                                                          Title = blogs.Title,
                                                          Body = blogs.Body,
                                                          AdminID = admin.ID,
                                                          AdminName = admin.Name,
                                                          TagsList = tags.ToList()
                                                      }).ToList().Skip(skip).Take(pageSize);
                db.Database.Connection.Close();
                return new List<BlogEntry>(blogEntries);
            }
        }
        private int GetTotal()
        {
            using (b3752Entities db = new b3752Entities())
            {
                db.Database.CommandTimeout = 5;
                db.Database.Connection.Open();
                int count = db.Blogs.Count();
                db.Database.Connection.Close();
                return count;
            }
        }
        private List<BlogEntry> GetBlogByPageNumber(int skip, int pageSize)
        {
            using (b3752Entities db = new b3752Entities())
            {
                db.Database.CommandTimeout = 5;
                db.Database.Connection.Open();
                db.Database.Log = Console.Write;
                IEnumerable<BlogEntry> blogEntries = new List<BlogEntry>(from blogs in db.Blogs
                                                                         let admin = blogs.Admins
                                                                         let blogsTags = blogs.BlogsTags
                                                                         let tags = blogs.BlogsTags.Select(i => i.Tags)
                                                                         orderby blogs.CreationDate descending
                                                                         select new BlogEntry
                                                                         {
                                                                             ID = blogs.ID,
                                                                             CreationDate = blogs.CreationDate,
                                                                             ModifyingDate = blogs.ModifyingDate,
                                                                             Url = blogs.Url,
                                                                             Title = blogs.Title,
                                                                             Body = blogs.Body,
                                                                             AdminID = admin.ID,
                                                                             AdminName = admin.Name,
                                                                             TagsList = tags.ToList()
                                                                         }).ToList().Skip(skip).Take(pageSize);
                db.Database.Connection.Close();
                return new List<BlogEntry>(blogEntries);
            }
        }

        private BlogEntry GetBlogByUrl(string url)
        {
            using (b3752Entities db = new b3752Entities())
            {
                db.Database.CommandTimeout = 5;
                db.Database.Connection.Open();
                db.Database.Log = Console.Write;
                BlogEntry blogEntry = (from blogs in db.Blogs
                                       let admin = blogs.Admins
                                       let blogsTags = blogs.BlogsTags
                                       let tags = blogs.BlogsTags.Select(i => i.Tags)
                                       where blogs.Url == url
                                       orderby blogs.CreationDate descending
                                       select new BlogEntry()
                                       {
                                           ID = blogs.ID,
                                           CreationDate = blogs.CreationDate,
                                           ModifyingDate = blogs.ModifyingDate,
                                           Url = blogs.Url,
                                           Title = blogs.Title,
                                           Body = blogs.Body,
                                           AdminID = admin.ID,
                                           AdminName = admin.Name,
                                           TagsList = tags.ToList()
                                       }).FirstOrDefault();
                db.Database.Connection.Close();
                return blogEntry;
            }
        }

        private List<BlogEntry> GetBlog(int pageSize, int skip)
        {
            using (b3752Entities db = new b3752Entities())
            {
                db.Database.CommandTimeout = 5;
                db.Database.Connection.Open();
                db.Database.Log = Console.Write;
                IEnumerable<BlogEntry> blogEntries = new List<BlogEntry>(from blogs in db.Blogs
                                                                         let admin = blogs.Admins
                                                                         let blogsTags = blogs.BlogsTags
                                                                         let tags = blogs.BlogsTags.Select(i => i.Tags)
                                                                         orderby blogs.CreationDate descending
                                                                         select new BlogEntry
                                                                         {
                                                                             ID = blogs.ID,
                                                                             CreationDate = blogs.CreationDate,
                                                                             ModifyingDate = blogs.ModifyingDate,
                                                                             Url = blogs.Url,
                                                                             Title = blogs.Title,
                                                                             Body = blogs.Body,
                                                                             AdminID = admin.ID,
                                                                             AdminName = admin.Name,
                                                                             TagsList = tags.ToList()
                                                                         }).ToList().Skip(skip).Take(pageSize);
                db.Database.Connection.Close();
                return new List<BlogEntry>(blogEntries);
            }
        }
    }
}