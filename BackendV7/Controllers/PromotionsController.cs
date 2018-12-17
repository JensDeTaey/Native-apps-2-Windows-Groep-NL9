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
    public class PromotionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Promotions
        public IQueryable<Promotion> GetPromotions()
        {
            return db.Promotions.Include(p => p.Establishment);
        }

        // GET: api/Promotions/5
        [ResponseType(typeof(Promotion))]
        public IHttpActionResult GetPromotion(int id)
        {
            Promotion promotion = db.Promotions.Find(id);
            if (promotion == null)
            {
                return NotFound();
            }

            return Ok(promotion);
        }

        // PUT: api/Promotions/5
        [ResponseType(typeof(void))]
        [Authorize]
        public IHttpActionResult PutPromotion(int id, EditPromotionViewModel model)
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
                .Include("Businesses.Establishments.Promotions")
                .Where(e => e.Id == user.Id).FirstOrDefault();

            Promotion promotion = foundUser.Businesses
                .SelectMany(b => b.Establishments)
                .SelectMany(e => e.Promotions)
                .Where(e => e.Id == id).FirstOrDefault();


            if (promotion != null)
            {
                try
                {

                    promotion.Id = id;
                    promotion.Description = model.Description;
                    promotion.Name = model.Name;
                    promotion.PictureURL = model.Picture;
                    promotion.StartDate = model.StartDate;
                    promotion.EndDate = model.EndDate;
                    promotion.IsDiscountCoupon = model.IsDiscountCoupon;

                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return Ok(promotion);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        [Authorize]
        public IHttpActionResult DeletePromotion(int id)
        {

            var user = db.Users.Where(el => el.UserName == this.User.Identity.Name).FirstOrDefault();

            if (user == null)
            {
                return Unauthorized();
            }


            ApplicationUser foundUser = db.Users
                .Include("Businesses.Establishments.Promotions")
                .Where(e => e.Id == user.Id).FirstOrDefault();

            Promotion promotion = foundUser.Businesses
                .SelectMany(b => b.Establishments)
                .SelectMany(e => e.Promotions)
                .Where(e => e.Id == id).FirstOrDefault();



            if (promotion == null)
            {
                return NotFound();
            }

            db.Promotions.Remove(promotion);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
            }
            return Ok(promotion);


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromotionExists(int id)
        {
            return db.Promotions.Count(e => e.Id == id) > 0;
        }
    }
}