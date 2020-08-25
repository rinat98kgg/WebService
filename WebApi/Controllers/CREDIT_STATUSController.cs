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
    public class CREDIT_STATUSController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/CREDIT_STATUS
        public IQueryable<CREDIT_STATUS> GetCREDIT_STATUS()
        {
            return db.CREDIT_STATUS;
        }

        // GET: api/CREDIT_STATUS/5
        [ResponseType(typeof(CREDIT_STATUS))]
        public IHttpActionResult GetCREDIT_STATUS(short id)
        {
            CREDIT_STATUS cREDIT_STATUS = db.CREDIT_STATUS.Find(id);
            if (cREDIT_STATUS == null)
            {
                return NotFound();
            }

            return Ok(cREDIT_STATUS);
        }

        // PUT: api/CREDIT_STATUS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCREDIT_STATUS(short id, CREDIT_STATUS cREDIT_STATUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cREDIT_STATUS.CSTATUS_ID)
            {
                return BadRequest();
            }

            db.Entry(cREDIT_STATUS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CREDIT_STATUSExists(id))
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

        // POST: api/CREDIT_STATUS
        [ResponseType(typeof(CREDIT_STATUS))]
        public IHttpActionResult PostCREDIT_STATUS(CREDIT_STATUS cREDIT_STATUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CREDIT_STATUS.Add(cREDIT_STATUS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CREDIT_STATUSExists(cREDIT_STATUS.CSTATUS_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cREDIT_STATUS.CSTATUS_ID }, cREDIT_STATUS);
        }

        // DELETE: api/CREDIT_STATUS/5
        [ResponseType(typeof(CREDIT_STATUS))]
        public IHttpActionResult DeleteCREDIT_STATUS(short id)
        {
            CREDIT_STATUS cREDIT_STATUS = db.CREDIT_STATUS.Find(id);
            if (cREDIT_STATUS == null)
            {
                return NotFound();
            }

            db.CREDIT_STATUS.Remove(cREDIT_STATUS);
            db.SaveChanges();

            return Ok(cREDIT_STATUS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CREDIT_STATUSExists(short id)
        {
            return db.CREDIT_STATUS.Count(e => e.CSTATUS_ID == id) > 0;
        }
    }
}