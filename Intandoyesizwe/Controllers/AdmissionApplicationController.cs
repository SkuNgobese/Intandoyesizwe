using Intandoyesizwe.Models;
using Intandoyesizwe.Models.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Intandoyesizwe.Controllers
{
    [AllowAnonymous]
    public class AdmissionApplicationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdmissionAppication
        public ActionResult Personal()
        {
            var closingDate = db.ApplicationsDates.ToList().Last().closeDate;
            if (closingDate < DateTime.Now)
            {
                return RedirectToAction("ApplicationsClosed", "AdmissionApplication");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Personal(PersonalVM personal)
        {
            if (ModelState.IsValid)
            {
                var admissionApplication = new AdmissionApplication { grade = personal.grade, prevGrade = personal.prevGrade, prevGradeYear = personal.prevGradeYear, year = DateTime.Today.Year + 1, date_ = DateTime.Now };
                db.AdmissionApplications.Add(admissionApplication);
                var idinfo = new IdentityInfo(personal.idNo);

                var persInfo = new Personal { Id = admissionApplication.Id, firstName = personal.firstName, otherNames = personal.otherNames, surname = personal.surname, initials = personal.initials, nickname = personal.nickname, idNo = personal.idNo, dob = idinfo.BirthDate, gender = idinfo.Gender, race = personal.race, dexterity = personal.dexterity, recSocGrant = personal.recSocGrant, regSocGrant = personal.regSocGrant, AdmissionApplication = admissionApplication };
                db.Personals.Add(persInfo);
                db.SaveChanges();
                TempData["id"] = admissionApplication.Id;
                return RedirectToAction("Contact");
            }
            return View(personal);
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactVM contact)
        {
            if (ModelState.IsValid)
            {
                var id = (int)TempData["id"];
                var admissionApplication = db.AdmissionApplications.Find(id);
                var cont = new Contact { Id = admissionApplication.Id, homeNo = contact.homeNo, emergNo = contact.emergNo, learnerNo = contact.learnerNo, Email = contact.Email, homeLanguage = contact.homeLanguage, deceasedParent = contact.deceasedParent, transportMode = contact.transportMode, AdmissionApplication = admissionApplication };
                db.Contacts.Add(cont);

                var physAddr = new PhysicalAddress { Id = admissionApplication.Id, street = contact.street, city = contact.city, suburb = contact.suburb, code = contact.code, AdmissionApplication = admissionApplication};
                db.PhysicalAddresses.Add(physAddr);
                db.SaveChanges();
                TempData["id"] = admissionApplication.Id;
                return RedirectToAction("PrevSchool");
            }
            return View(contact);
        }

        public ActionResult PrevSchool()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrevSchool(PrevSchoolVM prevSchool)
        {
            if (ModelState.IsValid)
            {
                var id = (int)TempData["id"];
                var admissionApplication = db.AdmissionApplications.Find(id);
                var prev = new PrevSchool { Id = admissionApplication.Id, schoolName = prevSchool.schoolName, street = prevSchool.street, suburb = prevSchool.suburb, city = prevSchool.city, code = prevSchool.code, province = prevSchool.province, AdmissionApplication = admissionApplication };
                db.PrevSchools.Add(prev);

                var corresp = new Correspondence { Id = admissionApplication.Id, title = prevSchool.title, lastName = prevSchool.lastName, firstLine = prevSchool.firstLine, city = prevSchool.city, code = prevSchool.code, AdmissionApplication = admissionApplication };
                db.Correspondences.Add(corresp);
                db.SaveChanges();
                TempData["id"] = admissionApplication.Id;
                return RedirectToAction("Parent");
            }
            return View(prevSchool);
        }

        public ActionResult Parent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Parent(ParentVM parent)
        {
            if (ModelState.IsValid)
            {
                var id = (int)TempData["id"];
                var admissionApplication = db.AdmissionApplications.Find(id);
                var parnt = new Parent { Id = admissionApplication.Id, title = parent.title, firstName = parent.firstName, lastName = parent.lastName, initials = parent.initials, idNo = parent.idNo, occupation = parent.occupation, resideswith = parent.resideswith, relationship = parent.relationship, familyPosition = parent.familyPosition, numberOfOtherChildren = parent.numberOfOtherChildren, AdmissionApplication = admissionApplication };
                db.Parents.Add(parnt);
                db.SaveChanges();
                return RedirectToAction("ThankYou");
            }
            return View(parent);
        }

        [AllowAnonymous]
        public JsonResult StudentIDExists(string idNo)
        {
            var isExist = db.Personals.ToList().Find(p => p.idNo == idNo);
            return Json(isExist == null, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult StudentIDDoesntExists(string idNo)
        {
            var isExist = db.Personals.ToList().Find(p => p.idNo == idNo);
            return Json(isExist != null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult CheckStatus()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckStatus(CheckStatus status)
        {
            if (ModelState.IsValid)
            {
                var results = db.AdmissionApplications.ToList().Find(p=>p.Personal.idNo == status.idNo);

                if (results.status == true && results.Rejected == null)
                {
                    TempData["status"] = "Accepted";
                    TempData["adm"] = results;
                }
                if(results.status == true && results.Rejected != null)
                {
                    TempData["status"] = "Rejected";
                    TempData["adm"] = results;
                }
                if (results.status == false)
                {
                    TempData["status"] = "Waiting";
                }
                return View();
            }
            return View(status);
        }
        public ActionResult ApplicationsClosed()
        {
            return View();
        }        
    }
}