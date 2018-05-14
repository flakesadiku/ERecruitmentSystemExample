using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERecruitmentSystem.DAL;
using ERecruitmentSystem.Models;

namespace ERecruitmentSystem.Controllers
{
    public class VacanciesApiController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/VacanciesApi
        public IQueryable<Vacancy> GetVacancies()
        {
            return db.Vacancies;
        }

        // GET: api/VacanciesApi/5
        [ResponseType(typeof(Vacancy))]
        public IHttpActionResult GetVacancy(int id)
        {
            Vacancy vacancy = db.Vacancies.Find(id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return Ok(vacancy);
        }

    
        // POST: api/VacanciesApi
        [ResponseType(typeof(Vacancy))]
        public IHttpActionResult PostVacancy(VacancyHelper vacancyHelper)
        {
            var action = vacancyHelper.action;
            var vacancy = vacancyHelper.vacancy;
            if (action == "create")
            {
                var result = AddNewVacancy(vacancy);
                if (result == false)
                {
                    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.BadRequest));
                }
            }
            else if (action == "update")
            {
                UpdateVacancy(vacancy);
            }
            else if (action == "delete")
            {
                DeleteVacancy(vacancy.Vacancy_Code);
            }

            return CreatedAtRoute("DefaultApi", new { id = vacancy.Vacancy_Code }, vacancy);
        }

        private bool AddNewVacancy(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                if (db.Vacancies.Any(x => x.Vacancy_Code == vacancy.Vacancy_Code))
                {
                    return false;
                }
                else
                {
                    db.Vacancies.Add(vacancy);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        private void UpdateVacancy(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacancy).State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        private void DeleteVacancy(int vacancy_Code)
        {
            var vacancy = db.Vacancies.Find(vacancy_Code);
            db.Vacancies.Remove(vacancy);
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VacancyExists(int id)
        {
            return db.Vacancies.Count(e => e.Vacancy_Code == id) > 0;
        }
    }
}