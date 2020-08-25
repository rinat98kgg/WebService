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
    public class BANKSController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/BANKS
        public IQueryable<BANKS> GetBANKS()
        {
            return db.BANKS.Include(b => b.LOCATIONS);
        }

        // GET: api/BANKS/5
        [ResponseType(typeof(BANKS))]
        public IHttpActionResult GetBANKS(int id)
        {
            BANKS bANKS = db.BANKS.Find(id);
            if (bANKS == null)
            {
                return NotFound();
            }

            return Ok(bANKS);
        }

        // PUT: api/BANKS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBANKS(int id, BANKS bANKS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bANKS.BANK_ID)
            {
                return BadRequest();
            }

            db.Entry(bANKS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BANKSExists(id))
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

        // POST: api/BANKS
        [ResponseType(typeof(BANKS))]
        public IHttpActionResult PostBANKS(BANKS bANKS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BANKS.Add(bANKS);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BANKSExists(bANKS.BANK_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bANKS.BANK_ID }, bANKS);
        }

        // DELETE: api/BANKS/5
        [ResponseType(typeof(BANKS))]
        public IHttpActionResult DeleteBANKS(int id)
        {
            BANKS bANKS = db.BANKS.Find(id);
            if (bANKS == null)
            {
                return NotFound();
            }

            db.BANKS.Remove(bANKS);
            db.SaveChanges();

            return Ok(bANKS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BANKSExists(int id)
        {
            return db.BANKS.Count(e => e.BANK_ID == id) > 0;
        }
    }
}