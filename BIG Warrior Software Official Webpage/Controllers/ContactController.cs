using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace BIG_Warrior_Software_Official_Webpage.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            if (Session["Notification"] != null && !String.IsNullOrEmpty(Session["Notification"].ToString()))
            {
                Random rnd = new Random();
                int number = rnd.Next(1000, 9999);
                byte[] imgBytes = turnImageToByteArray(DrawText(number.ToString(), new Font("Arial", 16.0f), Color.Black, Color.White));
                string imgString = Convert.ToBase64String(imgBytes);
                StringBuilder CaptchaHtmlImage = new StringBuilder();
                CaptchaHtmlImage.Append("<img class=\"Captcha\" src=\"data:image/Bmp;base64,");
                CaptchaHtmlImage.Append(imgString);
                CaptchaHtmlImage.Append("\"/>");

                Session["Captcha"] = number;
                ViewData["Captcha"] = CaptchaHtmlImage.ToString();
                ViewData["Notification"] = Session["Notification"].ToString();
                Session["Notification"] = String.Empty;
            }
            else
            {
                Random rnd = new Random();
                int number = rnd.Next(1000, 9999);
                byte[] imgBytes= turnImageToByteArray(DrawText(number.ToString(), new Font("Arial", 16.0f), Color.Black, Color.White));
                string imgString = Convert.ToBase64String(imgBytes);
                StringBuilder CaptchaHtmlImage = new StringBuilder();
                CaptchaHtmlImage.Append("<img class=\"Captcha\" src=\"data:image/Bmp;base64,");
                CaptchaHtmlImage.Append(imgString);
                CaptchaHtmlImage.Append("\"/>");

                Session["Captcha"] = number;
                ViewData["Captcha"] = CaptchaHtmlImage.ToString();
                ViewData["Notification"] = String.Empty;
            }
            return View();
        }

        public ActionResult SendMail()
        {
            NameValueCollection nvc = Request.Form;
            int errors = 0;
            StringBuilder sb = new StringBuilder();
            if (String.IsNullOrEmpty(nvc["Name"]))
            {
                sb.AppendLine("<p style=\"foreground: red;\">A név nincs kitöltve!</p>");
                errors++;
            }
            if (String.IsNullOrEmpty(nvc["Email"]))
            {
                sb.AppendLine("<p style=\"foreground: red;\">Az e-mail nincs kitöltve!</p>");
                errors++;
            }
            if (String.IsNullOrEmpty(nvc["Subject"]))
            {
                sb.AppendLine("<p style=\"foreground: red;\">A tárgy nincs kitöltve!</p>");
                errors++;
            }
            if (String.IsNullOrEmpty(nvc["Message"]))
            {
                sb.AppendLine("<p style=\"foreground: red;\">Az üzenet nincs kitöltve!</p>");
                errors++;
            }
            if (!IsValidEmail(nvc["Email"]))
            {
                sb.AppendLine("<p style=\"foreground: red;\">Az E-mail cím hibás!</p>");
                errors++;
            }
            if (String.IsNullOrEmpty(nvc["Captcha"]))
            {
                sb.AppendLine("<p style=\"foreground: red;\">A Captcha nem volt kitöltve!</p>");
                errors++;
            }
            else if (nvc["Captcha"].ToString() != Session["Captcha"].ToString())
            {
                sb.AppendLine("<p style=\"foreground: red;\">A Captcha nem egyezik!</p>");
                errors++;
            }
            if (errors > 0)
            {
                Session["Notification"] = sb.ToString();
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                GC.Collect();
                StringBuilder SubjectSB = new StringBuilder();

                SubjectSB.Append(nvc["Name"]);
                SubjectSB.Append(" (");
                SubjectSB.Append(nvc["Email"]);
                SubjectSB.Append("): ");
                SubjectSB.Append(nvc["Subject"]);
                StringBuilder MessageSB = new StringBuilder();
                MessageSB.Append(nvc["Message"]);
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.forpsi.com");

                    mail.From = new MailAddress("info@bigwarriorsoftware.hu", "BIGWarriorSoftware Info");
                    mail.To.Add("varga.mate@bigwarriorsoftware.hu");
                    mail.Subject = SubjectSB.ToString();
                    mail.Body = MessageSB.ToString();

                    SmtpServer.Port = 587;
                    SmtpServer.UseDefaultCredentials = true;
                    SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("postmaster@bigwarriorsoftware.hu", "tN6V27R5@P");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    Session["Notification"] = "<p style=\"color:green;\">Sikeres üzenetküldés!</p>";
                }
                catch (Exception)
                {
                    Session["Notification"] = "<p style=\"color:red;\">Nem sikerült az E-mail küldése!</p>";
                }
            }
            return RedirectToAction("Index", "Contact");
        }

        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        private Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;
        }

        private byte[] turnImageToByteArray(System.Drawing.Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }
    }
}