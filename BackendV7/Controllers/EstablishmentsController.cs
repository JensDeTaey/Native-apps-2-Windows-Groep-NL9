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
    public class EstablishmentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Establishments
        public IQueryable<Establishment> GetEstablishments()
        {
            return db.Establishments;
        }

        // GET: api/Establishments/5
        [ResponseType(typeof(Establishment))]
        public IHttpActionResult GetEstablishment(int id)
        {
            Establishment establishment = db.Establishments.Find(id);
            if (establishment == null)
            {
                return NotFound();
            }

            return Ok(establishment);
        }

        // PUT: api/Establishments/5
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult PutEstablishment(int id, EditEstablishmentViewModel model)
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
                .Include("Businesses.Establishments.OpeningHours")
                .Where(e => e.Id == user.Id).FirstOrDefault();

            Establishment establishment = foundUser.Businesses.SelectMany(b => b.Establishments).Where(e => e.Id == id).FirstOrDefault();


            if(establishment != null )
            {
                try
                {
                    db.OpeningHours.RemoveRange(db.OpeningHours.Where(o => o.EstablishmentId == establishment.Id));
                    db.SaveChanges();

                    establishment.Id = establishment.Id;
                    establishment.Name = model.Name;
                    establishment.Address = model.Address;
                    establishment.PhoneNumber = model.PhoneNumber;
                    establishment.Email = model.Email;
                    establishment.PictureURL = model.Picture;
                    establishment.OpeningHours = model.OpeningHours;

                    db.SaveChanges();
                } catch(DbUpdateConcurrencyException)
                {

                }
                return Ok(establishment);
            } else
            {
                return NotFound();
            }


            
        }

        // DELETE: api/Establishments/5
        [ResponseType(typeof(Establishment))]
        [Authorize]
        public IHttpActionResult DeleteEstablishment(int id)
        {

            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized();
            }


            ApplicationUser foundUser = db.Users
                .Include("Businesses.Establishments")
                .Where(e => e.Id == user.Id).FirstOrDefault();

            Establishment establishment = foundUser.Businesses.Where(e => e.UserId == user.Id).FirstOrDefault()
                .Establishments.Where(e => e.Id == id).FirstOrDefault();



            if (establishment == null)
            {
                return NotFound();
            }

            db.Establishments.Remove(establishment);
            try
            {
                db.SaveChanges();
            } catch (DbUpdateConcurrencyException)
            {
            }
            return Ok(establishment);


        }


        // POST: api/Establishments/1/AddEvent
        [ResponseType(typeof(Event))]
        [Route("api/Establishments/{establishmentId}/AddEvent")]
        [Authorize]
        public IHttpActionResult PostEvent(int establishmentId,EditEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized();
            }

            if (model == null)
            {
                return BadRequest("Give me some data to work with, yo");
            }

            var establishment = db.Users
                .Include("Businesses.Establishments.Events")
                .Where(u => u.Id == user.Id)
                .SelectMany(u => u.Businesses)
                .SelectMany(b => b.Establishments)
                .Where(e => e.Id == establishmentId)
                .FirstOrDefault();

            if(establishment != null)
            {

                var createdEvent = new Event()
                {
                    Name = model.Name,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PictureURL = model.Picture,
                    EstablishmentId = establishment.Id
                };
                db.Events.Add(createdEvent);
                db.SaveChanges();
                return Ok(createdEvent);
            } else
            {
                return NotFound();
            }

        }

        // POST: api/Establishments/1/AddPromotion
        [ResponseType(typeof(Promotion))]
        [Route("api/Establishments/{establishmentId}/AddPromotion")]
        [Authorize]
        public IHttpActionResult PostPromotion(int establishmentId, EditPromotionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized();
            }

            if (model == null)
            {
                return BadRequest("Give me some data to work with, yo");
            }

            var establishment = db.Users
                .Include("Businesses.Establishments.Promotions")
                .Where(u => u.Id == user.Id)
                .SelectMany(u => u.Businesses)
                .SelectMany(b => b.Establishments)
                .Where(e => e.Id == establishmentId)
                .FirstOrDefault();

            if (establishment != null)
            {

                var createdPromotion = new Promotion()
                {
                    Name = model.Name,
                    Description = model.Description,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PictureURL = model.Picture,
                    EstablishmentId = establishment.Id,
                    IsDiscountCoupon = model.IsDiscountCoupon
                };
                db.Promotions.Add(createdPromotion);
                db.SaveChanges();
                return Ok(createdPromotion);
            }
            else
            {
                return NotFound();
            }

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EstablishmentExists(int id)
        {
            return db.Establishments.Count(e => e.Id == id) > 0;
        }
    }
}