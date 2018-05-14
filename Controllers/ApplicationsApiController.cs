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
    public class ApplicationsApiController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/ApplicationsApi
        public IQueryable<Application> GetApplications()
        {
            return db.Applications.Include(a => a.Applicant).Include(a => a.Exam).Include(a => a.Vacancy).AsQueryable();
        }

        // GET: api/ApplicationsApi/5
        [ResponseType(typeof(Application))]
        public IHttpActionResult GetApplication(int id)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        // POST: api/ApplicationsApi
        [ResponseType(typeof(Application))]
        public IHttpActionResult PostApplication(ApplicationHelper applicationHelper)
        {
            {
                var action = applicationHelper.action;
                var application = applicationHelper.application;
                if (action == "create")
                {
                    AddNewApplication(application);
                }
                else if (action == "update")
                {
                    UpdateApplication(application);
                }
                else if (action == "delete")
                {
                    DeleteApplication(application.App_ID);
                }

                return CreatedAtRoute("DefaultApi", new { id = application.App_ID }, application);
            }
        }

            private void AddNewApplication(Application application)
            {
                if (ModelState.IsValid)
                {
                    db.Applications.Add(application);
                    db.SaveChanges();
                }
            }

            private void UpdateApplication(Application application)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(application).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }

            private void DeleteApplication(int app_Id)
            {
                var application = db.Applications.Find(app_Id);
                db.Applications.Remove(application);
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

        private bool ApplicationExists(int id)
        {
            return db.Applications.Count(e => e.App_ID == id) > 0;
        }
    }
}