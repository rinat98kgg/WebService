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
    public class MARITAL_STATUSController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/MARITAL_STATUS
        public IQueryable<MARITAL_STATUS> GetMARITAL_STATUS()
        {
            return db.MARITAL_STATUS;
        }

        // GET: api/MARITAL_STATUS/5
        [ResponseType(typeof(MARITAL_STATUS))]
        public IHttpActionResult GetMARITAL_STATUS(short id)
        {
            MARITAL_STATUS mARITAL_STATUS = db.MARITAL_STATUS.Find(id);
            if (mARITAL_STATUS == null)
            {
                return NotFound();
            }

            return Ok(mARITAL_STATUS);
        }

        // PUT: api/MARITAL_STATUS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMARITAL_STATUS(short id, MARITAL_STATUS mARITAL_STATUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mARITAL_STATUS.MSTATUS_ID)
            {
                return BadRequest();
            }

            db.Entry(mARITAL_STATUS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MARITAL_STATUSExists(id))
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

        // POST: api/MARITAL_STATUS
        [ResponseType(typeof(MARITAL_STATUS))]
        public IHttpActionResult PostMARITAL_STATUS(MARITAL_STATUS mARITAL_STATUS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MARITAL_STATUS.Add(mARITAL_STATUS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MARITAL_STATUSExists(mARITAL_STATUS.MSTATUS_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = mARITAL_STATUS.MSTATUS_ID }, mARITAL_STATUS);
        }

        // DELETE: api/MARITAL_STATUS/5
        [ResponseType(typeof(MARITAL_STATUS))]
        public IHttpActionResult DeleteMARITAL_STATUS(short id)
        {
            MARITAL_STATUS mARITAL_STATUS = db.MARITAL_STATUS.Find(id);
            if (mARITAL_STATUS == null)
            {
                return NotFound();
            }

            db.MARITAL_STATUS.Remove(mARITAL_STATUS);
            db.SaveChanges();

            return Ok(mARITAL_STATUS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MARITAL_STATUSExists(short id)
        {
            return db.MARITAL_STATUS.Count(e => e.MSTATUS_ID == id) > 0;
        }
    }
}