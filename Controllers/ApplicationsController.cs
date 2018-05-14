using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERecruitmentSystem.DAL;
using ERecruitmentSystem.Models;

namespace ERecruitmentSystem.Controllers
{
    public class ApplicationsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Applications
        public ActionResult Index()
        {
            var applications = db.Applications.Include(a => a.Applicant).Include(a => a.Exam).Include(a => a.Vacancy);
            return View(applications.ToList());
        }


        // GET: Applications/Create
        public ActionResult Create()
        {
            ViewBag.PersonalNumber = new SelectList(db.Applicants, "PersonalNumber", "FirstName");
            ViewBag.Exam_Id = new SelectList(db.Exams, "Exam_Id", "Exam_Description");
            ViewBag.Vacancy_Code = new SelectList(db.Vacancies, "Vacancy_Code", "Description");
            return View();
        }


        // GET: Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonalNumber = new SelectList(db.Applicants, "PersonalNumber", "FirstName", application.PersonalNumber);
            ViewBag.Exam_Id = new SelectList(db.Exams, "Exam_Id", "Exam_Description", application.Exam_Id);
            ViewBag.Vacancy_Code = new SelectList(db.Vacancies, "Vacancy_Code", "Description", application.Vacancy_Code);
            return View(application);
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
