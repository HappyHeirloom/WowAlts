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
    public class JoinCharactersController : ApiController
    {
        private WowAltsDBContext db = new WowAltsDBContext();

        // GET: api/JoinCharacters
        public IQueryable<JoinCharacter> GetJoinCharacter()
        {
            return db.JoinCharacter;
        }

        // GET: api/JoinCharacters/5
        [ResponseType(typeof(JoinCharacter))]
        public IHttpActionResult GetJoinCharacter(int id)
        {
            JoinCharacter joinCharacter = db.JoinCharacter.Find(id);
            if (joinCharacter == null)
            {
                return NotFound();
            }

            return Ok(joinCharacter);
        }

        // PUT: api/JoinCharacters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJoinCharacter(int id, JoinCharacter joinCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != joinCharacter.Id)
            {
                return BadRequest();
            }

            db.Entry(joinCharacter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoinCharacterExists(id))
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

        // POST: api/JoinCharacters
        [ResponseType(typeof(JoinCharacter))]
        public IHttpActionResult PostJoinCharacter(JoinCharacter joinCharacter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JoinCharacter.Add(joinCharacter);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (JoinCharacterExists(joinCharacter.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = joinCharacter.Id }, joinCharacter);
        }

        // DELETE: api/JoinCharacters/5
        [ResponseType(typeof(JoinCharacter))]
        public IHttpActionResult DeleteJoinCharacter(int id)
        {
            JoinCharacter joinCharacter = db.JoinCharacter.Find(id);
            if (joinCharacter == null)
            {
                return NotFound();
            }

            db.JoinCharacter.Remove(joinCharacter);
            db.SaveChanges();

            return Ok(joinCharacter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JoinCharacterExists(int id)
        {
            return db.JoinCharacter.Count(e => e.Id == id) > 0;
        }
    }
}