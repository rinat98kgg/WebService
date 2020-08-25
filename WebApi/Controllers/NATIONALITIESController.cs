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
    public class NATIONALITIESController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/NATIONALITIES
        public IQueryable<NATIONALITIES> GetNATIONALITIES()
        {
            return db.NATIONALITIES;
        }

        // GET: api/NATIONALITIES/5
        [ResponseType(typeof(NATIONALITIES))]
        public IHttpActionResult GetNATIONALITIES(short id)
        {
            NATIONALITIES nATIONALITIES = db.NATIONALITIES.Find(id);
            if (nATIONALITIES == null)
            {
                return NotFound();
            }

            return Ok(nATIONALITIES);
        }

        // PUT: api/NATIONALITIES/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNATIONALITIES(short id, NATIONALITIES nATIONALITIES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nATIONALITIES.NATIONALITY_ID)
            {
                return BadRequest();
            }

            db.Entry(nATIONALITIES).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NATIONALITIESExists(id))
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

        // POST: api/NATIONALITIES
        [ResponseType(typeof(NATIONALITIES))]
        public IHttpActionResult PostNATIONALITIES(NATIONALITIES nATIONALITIES)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NATIONALITIES.Add(nATIONALITIES);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NATIONALITIESExists(nATIONALITIES.NATIONALITY_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nATIONALITIES.NATIONALITY_ID }, nATIONALITIES);
        }

        // DELETE: api/NATIONALITIES/5
        [ResponseType(typeof(NATIONALITIES))]
        public IHttpActionResult DeleteNATIONALITIES(short id)
        {
            NATIONALITIES nATIONALITIES = db.NATIONALITIES.Find(id);
            if (nATIONALITIES == null)
            {
                return NotFound();
            }

            db.NATIONALITIES.Remove(nATIONALITIES);
            db.SaveChanges();

            return Ok(nATIONALITIES);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NATIONALITIESExists(short id)
        {
            return db.NATIONALITIES.Count(e => e.NATIONALITY_ID == id) > 0;
        }
    }
}