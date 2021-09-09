using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intandoyesizwe.Models.View_Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Intandoyesizwe.Models;
using System.Data.Entity;

namespace Intandoyesizwe.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Dashboard()
        {
            var _date = db.ApplicationsDates.ToList().Last();
            return View(_date);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dashboard([Bind(Include = "Id,openDate,closeDate")] ApplicationsDate applicationsDate)
        {
            OpenDate(applicationsDate.openDate, applicationsDate.closeDate);
            if(ModelState.IsValid)
            {
                db.ApplicationsDates.Add(applicationsDate);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View(applicationsDate);
        }
        [AllowAnonymous]
        public JsonResult OpenDate(DateTime openDate, DateTime closeDate)
        {
            bool isOk = true;
            if(openDate > closeDate || closeDate < openDate)
            {
                isOk = false;
                ModelState.AddModelError("", "Check your Dates!");
            }
            return Json(isOk == true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(ContactEmailVM model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Subject:{2}</p><p>Message:</p><p>{3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("info@intandoyesizwe.org"));  
                message.From = new MailAddress(model.FromEmail); 
                message.Subject = model.subject;
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.subject, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "",  // replace with valid value
                        Password = ""  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
    }
}