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
    public class CREDITSController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/CREDITS
        public IQueryable<CREDITS> GetCREDITS()
        {
            return db.CREDITS;
        }

        // GET: api/CREDITS/5
        [ResponseType(typeof(CREDITS))]
        public IHttpActionResult GetCREDITS(int id)
        {
            CREDITS cREDITS = db.CREDITS.Find(id);
            if (cREDITS == null)
            {
                return NotFound();
            }

            return Ok(cREDITS);
        }

        // PUT: api/CREDITS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCREDITS(int id, CREDITS cREDITS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cREDITS.CREDIT_ID)
            {
                return BadRequest();
            }

            db.Entry(cREDITS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CREDITSExists(id))
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

        // POST: api/CREDITS
        [ResponseType(typeof(CREDITS))]
        public IHttpActionResult PostCREDITS(CREDITS cREDITS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CREDITS.Add(cREDITS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CREDITSExists(cREDITS.CREDIT_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cREDITS.CREDIT_ID }, cREDITS);
        }

        // DELETE: api/CREDITS/5
        [ResponseType(typeof(CREDITS))]
        public IHttpActionResult DeleteCREDITS(int id)
        {
            CREDITS cREDITS = db.CREDITS.Find(id);
            if (cREDITS == null)
            {
                return NotFound();
            }

            db.CREDITS.Remove(cREDITS);
            db.SaveChanges();

            return Ok(cREDITS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CREDITSExists(int id)
        {
            return db.CREDITS.Count(e => e.CREDIT_ID == id) > 0;
        }
    }
}