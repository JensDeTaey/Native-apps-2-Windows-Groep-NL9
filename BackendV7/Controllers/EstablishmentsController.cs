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
                .Include(e => e.Business.Establishments)
                .Where(e => e.Id == user.Id).FirstOrDefault();

            Establishment establishment = foundUser.Business
                .Establishments.Find(e => e.Id == id);


            if(establishment != null )
            {
                establishment.Id = establishment.Id;
                establishment.Name = model.Name;
                establishment.Address = model.Address;
                establishment.PhoneNumber = model.PhoneNumber;
                establishment.Email = model.Email;
                establishment.PictureURL = model.PictureURL;
                establishment.OpeningHours = model.OpeningHours;

                db.SaveChanges();
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
                .Include(e => e.Business.Establishments)
                .Where(e => e.Id == user.Id).FirstOrDefault();

            Establishment establishment = foundUser.Business
                .Establishments.Where(e => e.Id == id).FirstOrDefault();



            if (establishment == null)
            {
                return NotFound();
            }

            db.Establishments.Remove(establishment);
            db.SaveChanges();

            return Ok(establishment);
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