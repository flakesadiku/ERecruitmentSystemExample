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
    public class VacanciesController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: Vacancies
        public ActionResult Index()
        {
            return View(db.Vacancies.ToList());
        }

        // GET: Vacancies/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Vacancies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return HttpNotFound();
            }
            return View(vacancy);
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
