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
using WowAltsWS;

namespace WowAltsWS.Controllers
{
    public class RealmsViewController : ApiController
    {
        private WowAltsDBContext db = new WowAltsDBContext();

        // GET: api/RealmsView
        public IQueryable<Realms> GetRealms()
        {
            return db.Realms;
        }

        // GET: api/RealmsView/5
        [ResponseType(typeof(Realms))]
        public IHttpActionResult GetRealms(int id)
        {
            Realms realms = db.Realms.Find(id);
            if (realms == null)
            {
                return NotFound();
            }

            return Ok(realms);
        }

        // PUT: api/RealmsView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRealms(int id, Realms realms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realms.Id)
            {
                return BadRequest();
            }

            db.Entry(realms).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealmsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RealmsView
        [ResponseType(typeof(Realms))]
        public IHttpActionResult PostRealms(Realms realms)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Realms.Add(realms);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RealmsExists(realms.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = realms.Id }, realms);
        }

        // DELETE: api/RealmsView/5
        [ResponseType(typeof(Realms))]
        public IHttpActionResult DeleteRealms(int id)
        {
            Realms realms = db.Realms.Find(id);
            if (realms == null)
            {
                return NotFound();
            }

            db.Realms.Remove(realms);
            db.SaveChanges();

            return Ok(realms);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealmsExists(int id)
        {
            return db.Realms.Count(e => e.Id == id) > 0;
        }
    }
}