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
    public class FactionsController : ApiController
    {
        private WowAltsDBContext db = new WowAltsDBContext();

        // GET: api/Factions
        public IQueryable<Faction> GetFaction()
        {
            return db.Faction;
        }

        // GET: api/Factions/5
        [ResponseType(typeof(Faction))]
        public IHttpActionResult GetFaction(int id)
        {
            Faction faction = db.Faction.Find(id);
            if (faction == null)
            {
                return NotFound();
            }

            return Ok(faction);
        }

        // PUT: api/Factions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFaction(int id, Faction faction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faction.Id)
            {
                return BadRequest();
            }

            db.Entry(faction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FactionExists(id))
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

        // POST: api/Factions
        [ResponseType(typeof(Faction))]
        public IHttpActionResult PostFaction(Faction faction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faction.Add(faction);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FactionExists(faction.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = faction.Id }, faction);
        }

        // DELETE: api/Factions/5
        [ResponseType(typeof(Faction))]
        public IHttpActionResult DeleteFaction(int id)
        {
            Faction faction = db.Faction.Find(id);
            if (faction == null)
            {
                return NotFound();
            }

            db.Faction.Remove(faction);
            db.SaveChanges();

            return Ok(faction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FactionExists(int id)
        {
            return db.Faction.Count(e => e.Id == id) > 0;
        }
    }
}