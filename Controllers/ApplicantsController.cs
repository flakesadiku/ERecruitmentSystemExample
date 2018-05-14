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
    public class ApplicantsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Applicants
        public ActionResult Index()
        {
            return View(db.Applicants.ToList());
        }

        // GET: Applicants/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Applicants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return HttpNotFound();
            }
            return View(applicant);
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
