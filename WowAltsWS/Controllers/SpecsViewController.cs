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
    public class SpecsViewController : ApiController
    {
        private WowAltsDBContext db = new WowAltsDBContext();

        // GET: api/SpecsView
        public IQueryable<Specs> GetSpecs()
        {
            return db.Specs;
        }

        // GET: api/SpecsView/5
        [ResponseType(typeof(Specs))]
        public IHttpActionResult GetSpecs(string id)
        {
            Specs specs = db.Specs.Find(id);
            if (specs == null)
            {
                return NotFound();
            }

            return Ok(specs);
        }

        // PUT: api/SpecsView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpecs(string id, Specs specs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specs.Class)
            {
                return BadRequest();
            }

            db.Entry(specs).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecsExists(id))
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

        // POST: api/SpecsView
        [ResponseType(typeof(Specs))]
        public IHttpActionResult PostSpecs(Specs specs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Specs.Add(specs);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SpecsExists(specs.Class))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = specs.Class }, specs);
        }

        // DELETE: api/SpecsView/5
        [ResponseType(typeof(Specs))]
        public IHttpActionResult DeleteSpecs(string id)
        {
            Specs specs = db.Specs.Find(id);
            if (specs == null)
            {
                return NotFound();
            }

            db.Specs.Remove(specs);
            db.SaveChanges();

            return Ok(specs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpecsExists(string id)
        {
            return db.Specs.Count(e => e.Class == id) > 0;
        }
    }
}