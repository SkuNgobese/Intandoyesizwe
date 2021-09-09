using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intandoyesizwe.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Intandoyesizwe.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdmissionApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdmissionApplications
        public ActionResult Index()
        {
            var admissionApplications = (from i in db.AdmissionApplications.ToList()
                                         orderby i.date_ descending, i.status ascending
                                         select i).ToList();           
            return View(admissionApplications);
        }
        public ActionResult Accept(int id)
        {
            TempData["id"] = id;
            return View();
        }

        [HttpPost, ActionName("Accept")]
        public ActionResult Accept()
        {
            var id = (int)(TempData["id"]);
            var admissionApplication = db.AdmissionApplications.Find(id);
            admissionApplication.status = true;
            db.SaveChanges();

            return RedirectToAction("Index", "AdmissionApplications");
        }

        public ActionResult Reject(int? id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reject(Rejected rejected, int? id)
        {
            if (ModelState.IsValid)
            {
                var admissionApplication = db.AdmissionApplications.Find(id);
                rejected.AdmissionApplication = admissionApplication;
                admissionApplication.status = true;
                rejected.date_ = DateTime.Now;
                db.Rejecteds.Add(rejected);
                db.SaveChanges();
                return RedirectToAction("Index", "AdmissionApplications");
            }
            return View(rejected);
        }
        // GET: AdmissionApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmissionApplication admissionApplication = db.AdmissionApplications.Find(id);
            if (admissionApplication == null)
            {
                return HttpNotFound();
            }
            return View(admissionApplication);
        }
        

        // GET: AdmissionApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdmissionApplication admissionApplication = db.AdmissionApplications.Find(id);
            if (admissionApplication == null)
            {
                return HttpNotFound();
            }
            return View(admissionApplication);
        }

        // POST: AdmissionApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdmissionApplication admissionApplication = db.AdmissionApplications.Find(id);
            var personal = db.Personals.Find(id);
            if(personal != null)
            {
                db.Personals.Remove(personal);
            }
            var contact = db.Contacts.Find(id);
            if(contact != null)
            {
                db.Contacts.Remove(contact);
            }
            var correspondance = db.Correspondences.Find(id);
            if(correspondance != null)
            {
                db.Correspondences.Remove(correspondance);
            }
            var parent = db.Parents.Find(id);
            if(parent != null)
            {
                db.Parents.Remove(parent);
            }
            var physical = db.PhysicalAddresses.Find(id);
            if(physical != null)
            {
                db.PhysicalAddresses.Remove(physical);
            }
            var prev = db.PrevSchools.Find(id);
            if(prev != null)
            {
                db.PrevSchools.Remove(prev);
            }
            var rej = db.Rejecteds.Find(id);
            if (rej != null)
            {
                db.Rejecteds.Remove(rej);
            }
            db.AdmissionApplications.Remove(admissionApplication);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public FileStreamResult Print(int id)
        {
            //Set up the document and the MS to write it to and create the PDF writer instance
            MemoryStream memStream = new MemoryStream();
            Document document = new Document(PageSize.A4, 10, 10, 10, 1);
            PdfWriter writer = PdfWriter.GetInstance(document, memStream);
            //MyEvent evnt = new MyEvent();
            //writer.PageEvent = evnt;
            writer.CloseStream = false;

            //Set up fonts used in the document
            Font HeaderFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, Font.BOLD + Font.UNDERLINE, BaseColor.BLACK);
            Font subHeaderFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 11, Font.BOLDITALIC, BaseColor.BLACK);
            Font bodyBoldFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, Font.BOLD, BaseColor.BLACK);
            Font bodyFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, Font.NORMAL, BaseColor.BLACK);
            Font redFont = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 18, Font.BOLD, BaseColor.DARK_GRAY);
            Font fontData = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, BaseColor.BLACK);

            //Open the PDF document\
            document.Open();

            Image img = Image.GetInstance(Server.MapPath("~/images/logo.jpg"));
            img.ScalePercent(9f);
            img.SetAbsolutePosition(document.PageSize.Width - 36f - 93f, document.PageSize.Height - 36f - 70f);

            PdfPTable tblHeader = new PdfPTable(3)
            {
                SpacingBefore = 50f,
                SpacingAfter = 50f
            };

            PdfPCell hCell0 = new PdfPCell(new Phrase("\nIntandoyesizwe Secondary School\n", HeaderFont))
            {
                HorizontalAlignment = 3,
                Colspan = 3,
                Border = 0,
            };

            PdfPCell hCell1 = new PdfPCell(new Phrase("Mbhense Tribal Authority Area, Uitval", bodyBoldFont))
            {
                Border = 0,
                Colspan = 3,
                HorizontalAlignment = 3
            };
            PdfPCell hCell4 = new PdfPCell(new Phrase("Wasbank", bodyBoldFont))
            {
                Border = 0,
                Colspan = 3,
                HorizontalAlignment = 3
            };
            PdfPCell hCell5 = new PdfPCell(new Phrase("2920", bodyBoldFont))
            {
                Border = 0,
                Colspan = 3,
                HorizontalAlignment = 3
            };

            PdfPCell hCell2 = new PdfPCell(new Phrase("Tel: 087 1700 849", bodyBoldFont))
            {
                Border = 0,
                Colspan = 3,
                HorizontalAlignment = 3
            };
            PdfPCell hCell3 = new PdfPCell(new Phrase("Email :admin@intandoyesizwe.org", bodyBoldFont))
            {
                Colspan = 3,
                Border = 0,
                HorizontalAlignment = 3
            };
            var student = db.AdmissionApplications.ToList().Find(x => x.Id == id);
            PdfPTable address = new PdfPTable(3)
            {
                SpacingBefore = 50f,
                SpacingAfter = 50f
            };

            tblHeader.AddCell(hCell0);
            tblHeader.AddCell(hCell1);
            tblHeader.AddCell(hCell4);
            tblHeader.AddCell(hCell5);
            tblHeader.AddCell(hCell2);
            tblHeader.AddCell(hCell3);

            document.Add(img);
            document.Add(tblHeader);

            Paragraph gap = new Paragraph("\n");


            //To get one  ready for print
            PdfContentByte bp = writer.DirectContent;
            PdfPTable personalTable = new PdfPTable(2);
            PdfPTable parentTable = new PdfPTable(2);
            PdfPTable correspondanceTable = new PdfPTable(1);
            PdfPTable schoolTable = new PdfPTable(2);
            PdfPTable stampTable = new PdfPTable(2);

            PdfPCell b = new PdfPCell(new Phrase("                        School Admission Application", redFont)) { Colspan = 2, HorizontalAlignment = 3, Border = 0 };
            correspondanceTable.AddCell(b);

            if (student.Correspondence != null)
            {
                PdfPCell b1 = new PdfPCell(new Phrase(student.Correspondence.title + " " + student.Correspondence.lastName, bodyBoldFont)) { Colspan = 2, HorizontalAlignment = 3, Border = 0 };
                correspondanceTable.AddCell(b1);
                PdfPCell b5 = new PdfPCell(new Phrase(student.Correspondence.firstLine, bodyFont)) { Colspan = 2, HorizontalAlignment = 3, Border = 0 };
                correspondanceTable.AddCell(b5);
                PdfPCell b3 = new PdfPCell(new Phrase(student.Correspondence.city, bodyFont)) { Colspan = 2, HorizontalAlignment = 3, Border = 0 };
                correspondanceTable.AddCell(b3);
                PdfPCell b4 = new PdfPCell(new Phrase(student.Correspondence.code, bodyFont)) { Colspan = 2, HorizontalAlignment = 3, Border = 0 };
                correspondanceTable.AddCell(b4);

                document.Add(correspondanceTable);
            }

            if (student != null)
            {
                var paragraph = new Paragraph("Personal Information", redFont);
                paragraph.Alignment = Element.ALIGN_CENTER;
                document.Add(paragraph);
                document.Add(gap);

                PdfPCell h1 = new PdfPCell(new Phrase("Full Name            :" + student.Personal.fullName, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h1);
                PdfPCell h2 = new PdfPCell(new Phrase("Nick Name            :" + student.Personal.nickname, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h2);
                PdfPCell h3 = new PdfPCell(new Phrase("ID Number            :" + student.Personal.idNo, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h3);
                PdfPCell h4 = new PdfPCell(new Phrase("Date of Birth            :" + student.Personal.dob.ToString("dd-MMMM-yyyy"), bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h4);
                PdfPCell h5 = new PdfPCell(new Phrase("Gender           :" + student.Personal.gender, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h5);
                var idinfo = new IdentityInfo(student.Personal.idNo);
                PdfPCell h7 = new PdfPCell(new Phrase("Age          :" + idinfo.Age, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h7);
                PdfPCell h6 = new PdfPCell(new Phrase("Race         :" + student.Personal.race, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h6);
                PdfPCell h8 = new PdfPCell(new Phrase("Learner Cell             :" + student.Contact.learnerNo, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h8);
                PdfPCell h9 = new PdfPCell(new Phrase("Learner Email            :" + student.Contact.Email, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h9);
                PdfPCell h10 = new PdfPCell(new Phrase("Dexterity               :" + student.Personal.dexterity, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h10);
                PdfPCell h11 = new PdfPCell(new Phrase("Reg Social Grant                :" + student.Personal.regSocGrant, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h11);
                PdfPCell h12 = new PdfPCell(new Phrase("Rec Social Grant                :" + student.Personal.recSocGrant, bodyFont)) { Colspan = 2 };
                personalTable.AddCell(h12);

                document.Add(personalTable);
                document.Add(gap);
            }

            if (student.Parent != null)
            {
                var paragraph1 = new Paragraph("Parent/Guardian Info", redFont);
                paragraph1.Alignment = Element.ALIGN_CENTER;
                document.Add(paragraph1);
                document.Add(gap);

                PdfPCell d1 = new PdfPCell(new Phrase("Name             :" + student.Parent.fullName, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d1);
                PdfPCell d2 = new PdfPCell(new Phrase("Initials             :" + student.Parent.initials, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d2);
                PdfPCell d3 = new PdfPCell(new Phrase("ID Number                :" + student.Parent.idNo, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d3);
                PdfPCell d4 = new PdfPCell(new Phrase("Occupation               :" + student.Parent.occupation, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d4);
                PdfPCell d5 = new PdfPCell(new Phrase("Learner resides with this parent             :" + student.Parent.resideswith, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d5);
                PdfPCell d6 = new PdfPCell(new Phrase("Relationship             :" + student.Parent.relationship, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d6);
                PdfPCell d7 = new PdfPCell(new Phrase("Number of Children at this School                :" + student.Parent.numberOfOtherChildren, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d7);
                PdfPCell d8 = new PdfPCell(new Phrase("Learner Position in the Family               :" + student.Parent.familyPosition, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d8);
                PdfPCell d9 = new PdfPCell(new Phrase("Home Contact             :" + student.Contact.homeNo, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d9);
                PdfPCell d10 = new PdfPCell(new Phrase("Emergency Contact               :" + student.Contact.emergNo, bodyFont)) { Colspan = 2 };
                parentTable.AddCell(d10);

                document.Add(parentTable);
                document.Add(gap);
            }

            if (student.PrevSchool != null)
            {
                var paragraph2 = new Paragraph("School Information", redFont);
                paragraph2.Alignment = Element.ALIGN_CENTER;
                document.Add(paragraph2);
                document.Add(gap);

                PdfPCell b1 = new PdfPCell(new Phrase("Grade Applied For            :" + student.grade, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b1);
                PdfPCell b2 = new PdfPCell(new Phrase("Year             :" + student.year, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b2);
                PdfPCell b3 = new PdfPCell(new Phrase("Highest Grade Passed             :" + student.prevGrade, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b3);
                PdfPCell b4 = new PdfPCell(new Phrase("Year When Grade was Passed               :" + student.prevGradeYear, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b4);
                PdfPCell b5 = new PdfPCell(new Phrase("Name of Previous School              :" + student.PrevSchool.schoolName, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b5);
                PdfPCell b6 = new PdfPCell(new Phrase("Province                 :" + student.PrevSchool.province, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b6);
                PdfPCell b7 = new PdfPCell(new Phrase("Street               :" + student.PrevSchool.street, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b7);
                PdfPCell b9 = new PdfPCell(new Phrase("Suburb               :" + student.PrevSchool.suburb, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b9);
                PdfPCell b10 = new PdfPCell(new Phrase("City                :" + student.PrevSchool.city, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b10);
                PdfPCell b11 = new PdfPCell(new Phrase("Code                :" + student.PrevSchool.code, bodyFont)) { Colspan = 2 };
                schoolTable.AddCell(b11);

                document.Add(schoolTable);
                document.Add(gap);
            }

            document.Close();

            byte[] file = memStream.ToArray();
            memStream.Write(file, 0, file.Length);
            memStream.Position = 0;

            return new FileStreamResult(memStream, "application/pdf");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
