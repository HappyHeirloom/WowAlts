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
    public class ClassesViewController : ApiController
    {
        private WowAltsDBContext db = new WowAltsDBContext();

        // GET: api/ClassesView
        public IQueryable<Classes> GetClasses()
        {
            return db.Classes;
        }

        // GET: api/ClassesView/5
        [ResponseType(typeof(Classes))]
        public IHttpActionResult GetClasses(int id)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();
            }

            return Ok(classes);
        }

        // PUT: api/ClassesView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClasses(int id, Classes classes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != classes.Id)
            {
                return BadRequest();
            }

            db.Entry(classes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassesExists(id))
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

        // POST: api/ClassesView
        [ResponseType(typeof(Classes))]
        public IHttpActionResult PostClasses(Classes classes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Classes.Add(classes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClassesExists(classes.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = classes.Id }, classes);
        }

        // DELETE: api/ClassesView/5
        [ResponseType(typeof(Classes))]
        public IHttpActionResult DeleteClasses(int id)
        {
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return NotFound();
            }

            db.Classes.Remove(classes);
            db.SaveChanges();

            return Ok(classes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClassesExists(int id)
        {
            return db.Classes.Count(e => e.Id == id) > 0;
        }
    }
}