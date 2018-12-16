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
using BackendV7.Authorization;
using BackendV7.Models;
using BackendV7.Models.ViewModels;

namespace BackendV7.Controllers
{
    public class BusinessesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Businesses
        public IQueryable<Business> GetBusinesses()
        {
            return db.Businesses.Include(b => b.Subscriptions);
        }

        // GET: api/Businesses/5
        [ResponseType(typeof(Business))]
        public IHttpActionResult GetBusiness(int id)
        {
            Business business = db.Businesses
                .Include(b => b.Establishments)
                .Include(b => b.Subscriptions)
                .Include("Establishments.OpeningHours")
                .Include("Establishments.Events")
                .Include("Establishments.Promotions")
                .SingleOrDefault(b => b.Id == id);
            if (business == null)
            {
                return NotFound();
            }

            return Ok(business);
        }

        // PUT: api/Businesses/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBusiness(int id, EditBusinessViewModel business)
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

            if(business == null)
            {
                return BadRequest("Give me some data to work with, yo");
            }

            var dBbusiness = db.Businesses.Find(id);

            if(dBbusiness != null)
            {
                dBbusiness.Name = business.Name;
                dBbusiness.Description = business.Description;
                dBbusiness.Category = business.Category;
                dBbusiness.LinkWebsite = business.LinkWebsite;
                dBbusiness.PictureURL = business.PictureURL;

                db.SaveChanges();
                return Ok();
            } else
            {
                return NotFound();
            }
        }

        // POST: api/Businesses/{id}/AddEstablishment
        [Route("api/Businesses/{id}/AddEstablishment")]
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult AddEstablishment(int id,EditEstablishmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if(user ==null)
            {
                return Unauthorized();
            }

            if (model == null)
            {
                return BadRequest("Give me some data to work with, yo");
            }


            if(db.Businesses.Find(id) != null)
            {

                Establishment establishment = new Establishment()
                {
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    PictureURL = model.PictureURL,
                    BusinessId = id,
                    OpeningHours = model.OpeningHours
                    
                };

                db.Establishments.Add(establishment);
                db.SaveChanges();
                return Ok(establishment);
            } else
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }


        // POST: api/Businesses/{id}/Subscribe
        [Route("api/Businesses/{id}/Subscribe")]
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult Subscribe(int id)
        {

            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return StatusCode(HttpStatusCode.Unauthorized);
            }


            if (db.Businesses.Find(id) != null)
            {

                var count = db.Subscriptions.Count(s => (s.BusinessId == id) && (s.UserId == user.Id));
                if (count == 0)
                {
                    Subscription subscription = new Subscription();
                    subscription.BusinessId = id;
                    subscription.UserId = user.Id;

                    db.Subscriptions.Add(subscription);
                }

                db.SaveChanges();

                return StatusCode(HttpStatusCode.Created);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Businesses/{id}/Unsubscribe
        [Route("api/Businesses/{id}/Unsubscribe")]
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult Unsubscribe(int id)
        {
            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized();
            }

            db.Subscriptions.RemoveRange(db.Subscriptions.Where(s => (s.BusinessId == id) && (s.UserId == user.Id)));
            db.SaveChanges();
            return StatusCode(HttpStatusCode.OK); 
        }

        // GET: api/Businesses
        [Route("api/SubscribedBusinesses")]
        [Authorize]
        public IHttpActionResult GetSubscribedBusinesses()
        {
            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(db.Subscriptions
                .Include(s => s.Business)
                .Where(s => s.UserId == user.Id)
                .Select(s => s.Business));
               
        }

        /*// DELETE: api/Businesses/5
        [ResponseType(typeof(Business))]
        public IHttpActionResult DeleteBusiness(int id)
        {
            Business business = db.Businesses.Find(id);
            if (business == null)
            {
                return NotFound();
            }

            db.Businesses.Remove(business);
            db.SaveChanges();

            return Ok(business);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusinessExists(int id)
        {
            return db.Businesses.Count(e => e.Id == id) > 0;
        }

    }



}