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
    public class FactionsViewController : ApiController
    {
        private WowAltsDBContext db = new WowAltsDBContext();

        // GET: api/FactionsView
        public IQueryable<Factions> GetFactions()
        {
            return db.Factions;
        }

        // GET: api/FactionsView/5
        [ResponseType(typeof(Factions))]
        public IHttpActionResult GetFactions(int id)
        {
            Factions factions = db.Factions.Find(id);
            if (factions == null)
            {
                return NotFound();
            }

            return Ok(factions);
        }

        // PUT: api/FactionsView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFactions(int id, Factions factions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != factions.Id)
            {
                return BadRequest();
            }

            db.Entry(factions).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactionsExists(id))
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

        // POST: api/FactionsView
        [ResponseType(typeof(Factions))]
        public IHttpActionResult PostFactions(Factions factions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Factions.Add(factions);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FactionsExists(factions.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = factions.Id }, factions);
        }

        // DELETE: api/FactionsView/5
        [ResponseType(typeof(Factions))]
        public IHttpActionResult DeleteFactions(int id)
        {
            Factions factions = db.Factions.Find(id);
            if (factions == null)
            {
                return NotFound();
            }

            db.Factions.Remove(factions);
            db.SaveChanges();

            return Ok(factions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FactionsExists(int id)
        {
            return db.Factions.Count(e => e.Id == id) > 0;
        }
    }
}