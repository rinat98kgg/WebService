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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class GENDERsController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/GENDERs
        public IQueryable<GENDER> GetGENDER()
        {
            return db.GENDER;
        }

        // GET: api/GENDERs/5
        [ResponseType(typeof(GENDER))]
        public IHttpActionResult GetGENDER(short id)
        {
            GENDER gENDER = db.GENDER.Find(id);
            if (gENDER == null)
            {
                return NotFound();
            }

            return Ok(gENDER);
        }

        // PUT: api/GENDERs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGENDER(short id, GENDER gENDER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gENDER.GENDER_ID)
            {
                return BadRequest();
            }

            db.Entry(gENDER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GENDERExists(id))
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

        // POST: api/GENDERs
        [ResponseType(typeof(GENDER))]
        public IHttpActionResult PostGENDER(GENDER gENDER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GENDER.Add(gENDER);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GENDERExists(gENDER.GENDER_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gENDER.GENDER_ID }, gENDER);
        }

        // DELETE: api/GENDERs/5
        [ResponseType(typeof(GENDER))]
        public IHttpActionResult DeleteGENDER(short id)
        {
            GENDER gENDER = db.GENDER.Find(id);
            if (gENDER == null)
            {
                return NotFound();
            }

            db.GENDER.Remove(gENDER);
            db.SaveChanges();

            return Ok(gENDER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GENDERExists(short id)
        {
            return db.GENDER.Count(e => e.GENDER_ID == id) > 0;
        }
    }
}