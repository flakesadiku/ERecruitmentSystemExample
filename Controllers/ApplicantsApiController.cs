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
    public class ApplicantsApiController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/ApplicantsApi
        public IQueryable<Applicant> Get()
        {
            return db.Applicants.AsQueryable();
        }

        // GET: api/ApplicantsApi/5
        [ResponseType(typeof(Applicant))]
        public IHttpActionResult Get(int id)
        {
            Applicant applicant = db.Applicants.Find(id);
            if (applicant == null)
            {
                return NotFound();
            }

            return Ok(applicant);
        }

       

        // POST: api/ApplicantsApi
        [ResponseType(typeof(Applicant))]
        [HttpPost]
        public IHttpActionResult Post(ApplicantHelper applicantHelper)
        {
            var action = applicantHelper.action;
            var applicant = applicantHelper.applicant;
            if (action == "create")
            {
                AddNewApplicant(applicant);
            }
            else if(action == "update")
            {
                UpdateApplicant(applicant);
            }
            else if(action == "delete")
            {
                DeleteApplicant(applicant.PersonalNumber);
            }

            return CreatedAtRoute("DefaultApi", new { id = applicant.PersonalNumber }, applicant);
        }

        private void AddNewApplicant(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Applicants.Add(applicant);
                db.SaveChanges();
            }
        }

        private void UpdateApplicant(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        private void DeleteApplicant(int personalNumber)
        {
            var applicant = db.Applicants.Find(personalNumber);
            db.Applicants.Remove(applicant);
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

        private bool ApplicantExists(int id)
        {
            return db.Applicants.Count(e => e.PersonalNumber == id) > 0;
        }
    }
}