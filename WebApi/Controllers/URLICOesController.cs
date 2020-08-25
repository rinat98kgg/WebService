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
    public class URLICOesController : ApiController
    {
        private Entities1 db = new Entities1();

        // GET: api/URLICOes
        public IQueryable<URLICO> GetURLICO()
        {
            return db.URLICO;
        }

        // GET: api/URLICOes/5
        [ResponseType(typeof(URLICO))]
        public IHttpActionResult GetURLICO(int id)
        {
            URLICO uRLICO = db.URLICO.Find(id);
            if (uRLICO == null)
            {
                return NotFound();
            }

            return Ok(uRLICO);
        }

        // PUT: api/URLICOes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutURLICO(int id, URLICO uRLICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uRLICO.URLICO_ID)
            {
                return BadRequest();
            }

            db.Entry(uRLICO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!URLICOExists(id))
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

        // POST: api/URLICOes
        [ResponseType(typeof(URLICO))]
        public IHttpActionResult PostURLICO(URLICO uRLICO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.URLICO.Add(uRLICO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (URLICOExists(uRLICO.URLICO_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uRLICO.URLICO_ID }, uRLICO);
        }

        // DELETE: api/URLICOes/5
        [ResponseType(typeof(URLICO))]
        public IHttpActionResult DeleteURLICO(int id)
        {
            URLICO uRLICO = db.URLICO.Find(id);
            if (uRLICO == null)
            {
                return NotFound();
            }

            db.URLICO.Remove(uRLICO);
            db.SaveChanges();

            return Ok(uRLICO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool URLICOExists(int id)
        {
            return db.URLICO.Count(e => e.URLICO_ID == id) > 0;
        }
    }
}