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
    public class FIZLICOesController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/FIZLICOes
        public List<FIZLICO> GetFIZLICO()
        {
            return db.FIZLICO
                .Include(g => g.GENDER).Include(m => m.MARITAL_STATUS).Include(n => n.NATIONALITIES).Include(c => c.CREDITS).Include(l => l.LOCATIONS).ToList();
        }

        // GET: api/FIZLICOes/5
        [ResponseType(typeof(FIZLICO))]
        public IHttpActionResult GetFIZLICO(int id)
        {
            FIZLICO fIZLICO = db.FIZLICO.Find(id);
            if (fIZLICO == null)
            {
                return NotFound();
            }

            return Ok(fIZLICO);
        }

        // PUT: api/FIZLICOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFIZLICO(int id, FIZLICO fIZLICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fIZLICO.FIZLICO_ID)
            {
                return BadRequest();
            }

            db.Entry(fIZLICO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FIZLICOExists(id))
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

        // POST: api/FIZLICOes
        [ResponseType(typeof(FIZLICO))]
        public IHttpActionResult PostFIZLICO(FIZLICO fIZLICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FIZLICO.Add(fIZLICO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (FIZLICOExists(fIZLICO.FIZLICO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = fIZLICO.FIZLICO_ID }, fIZLICO);
        }

        // DELETE: api/FIZLICOes/5
        [ResponseType(typeof(FIZLICO))]
        public IHttpActionResult DeleteFIZLICO(int id)
        {
            FIZLICO fIZLICO = db.FIZLICO.Find(id);
            if (fIZLICO == null)
            {
                return NotFound();
            }

            db.FIZLICO.Remove(fIZLICO);
            db.SaveChanges();

            return Ok(fIZLICO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FIZLICOExists(int id)
        {
            return db.FIZLICO.Count(e => e.FIZLICO_ID == id) > 0;
        }
    }
}