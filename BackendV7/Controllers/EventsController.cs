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
using BackendV7;
using BackendV7.Models;
using BackendV7.Models.ViewModels;

namespace BackendV7.Controllers
{
    public class EventsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Events
        public IQueryable<Event> GetEvents()
        {
            return db.Events.Include(p => p.Establishment);
        }

        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public IHttpActionResult GetEvent(int id)
        {
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }

        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult PutEvent(int id, EditEventViewModel model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized();
            }


            ApplicationUser foundUser = db.Users
                .Include("Businesses.Establishments.Events")
                .Where(e => e.Id == user.Id).FirstOrDefault();

            Event @event = foundUser.Businesses
                .SelectMany(b => b.Establishments)
                .SelectMany(e => e.Events)
                .Where(e => e.Id == id).FirstOrDefault();


            if (@event != null)
            {
                try
                {

                    @event.Id = id;
                    @event.Description = model.Description;
                    @event.Name = model.Name;
                    @event.PictureURL = model.PictureURL;
                    @event.StartDate = model.StartDate;
                    @event.EndDate = model.EndDate;

                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return Ok(@event);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        [Authorize]
        public IHttpActionResult DeleteEvent(int id)
        {

            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized();
            }


            ApplicationUser foundUser = db.Users
                .Include("Businesses.Establishments.Events")
                .Where(e => e.Id == user.Id).FirstOrDefault();

            Event @event = foundUser.Businesses
                .SelectMany(b => b.Establishments)
                .SelectMany(e => e.Events)
                .Where(e => e.Id == id).FirstOrDefault();



            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return Ok(@event);


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}