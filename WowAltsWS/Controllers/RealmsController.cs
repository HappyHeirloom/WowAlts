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
    public class RealmsController : ApiController
    {
        private WowAltsDBContext db = new WowAltsDBContext();

        // GET: api/Realms
        public IQueryable<Realm> GetRealm()
        {
            return db.Realm;
        }

        // GET: api/Realms/5
        [ResponseType(typeof(Realm))]
        public IHttpActionResult GetRealm(int id)
        {
            Realm realm = db.Realm.Find(id);
            if (realm == null)
            {
                return NotFound();
            }

            return Ok(realm);
        }

        // PUT: api/Realms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRealm(int id, Realm realm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != realm.Id)
            {
                return BadRequest();
            }

            db.Entry(realm).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealmExists(id))
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

        // POST: api/Realms
        [ResponseType(typeof(Realm))]
        public IHttpActionResult PostRealm(Realm realm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Realm.Add(realm);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RealmExists(realm.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = realm.Id }, realm);
        }

        // DELETE: api/Realms/5
        [ResponseType(typeof(Realm))]
        public IHttpActionResult DeleteRealm(int id)
        {
            Realm realm = db.Realm.Find(id);
            if (realm == null)
            {
                return NotFound();
            }

            db.Realm.Remove(realm);
            db.SaveChanges();

            return Ok(realm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RealmExists(int id)
        {
            return db.Realm.Count(e => e.Id == id) > 0;
        }
    }
}