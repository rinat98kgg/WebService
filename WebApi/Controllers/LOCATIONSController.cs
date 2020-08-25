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
    public class LOCATIONSController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/LOCATIONS
        public IQueryable<LOCATIONS> GetLOCATIONS()
        {
            return db.LOCATIONS;
        }

        // GET: api/LOCATIONS/5
        [ResponseType(typeof(LOCATIONS))]
        public IHttpActionResult GetLOCATIONS(int id)
        {
            LOCATIONS lOCATIONS = db.LOCATIONS.Find(id);
            if (lOCATIONS == null)
            {
                return NotFound();
            }

            return Ok(lOCATIONS);
        }

        // PUT: api/LOCATIONS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLOCATIONS(int id, LOCATIONS lOCATIONS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lOCATIONS.LOCATION_ID)
            {
                return BadRequest();
            }

            db.Entry(lOCATIONS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LOCATIONSExists(id))
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

        // POST: api/LOCATIONS
        [ResponseType(typeof(LOCATIONS))]
        public IHttpActionResult PostLOCATIONS(LOCATIONS lOCATIONS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LOCATIONS.Add(lOCATIONS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LOCATIONSExists(lOCATIONS.LOCATION_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lOCATIONS.LOCATION_ID }, lOCATIONS);
        }

        // DELETE: api/LOCATIONS/5
        [ResponseType(typeof(LOCATIONS))]
        public IHttpActionResult DeleteLOCATIONS(int id)
        {
            LOCATIONS lOCATIONS = db.LOCATIONS.Find(id);
            if (lOCATIONS == null)
            {
                return NotFound();
            }

            db.LOCATIONS.Remove(lOCATIONS);
            db.SaveChanges();

            return Ok(lOCATIONS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LOCATIONSExists(int id)
        {
            return db.LOCATIONS.Count(e => e.LOCATION_ID == id) > 0;
        }
    }
}