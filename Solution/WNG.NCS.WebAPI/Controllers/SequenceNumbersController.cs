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
using WNG.NCS.Model;

namespace WNG.NCS.WebAPI.Controllers
{
    public class SequenceNumbersController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/SequenceNumbers
        public IQueryable<SequenceNumber> GetSequenceNumbers()
        {
            return db.SequenceNumbers;
        }

        // GET: api/SequenceNumbers/5
        [ResponseType(typeof(SequenceNumber))]
        public IHttpActionResult GetSequenceNumber(int id)
        {
            SequenceNumber sequenceNumber = db.SequenceNumbers.Find(id);
            if (sequenceNumber == null)
            {
                return NotFound();
            }

            return Ok(sequenceNumber);
        }

        // PUT: api/SequenceNumbers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSequenceNumber(int id, SequenceNumber sequenceNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sequenceNumber.SequenceNumberId)
            {
                return BadRequest();
            }

            db.Entry(sequenceNumber).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SequenceNumberExists(id))
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

        // POST: api/SequenceNumbers
        [ResponseType(typeof(SequenceNumber))]
        public IHttpActionResult PostSequenceNumber(SequenceNumber sequenceNumber)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (sequenceNumber.Number % 1 != 0)
            {
                return BadRequest(ModelState);
            }

            db.SequenceNumbers.Add(sequenceNumber);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sequenceNumber.SequenceNumberId }, sequenceNumber);
        }

        // DELETE: api/SequenceNumbers/5
        [ResponseType(typeof(SequenceNumber))]
        public IHttpActionResult DeleteSequenceNumber(int id)
        {
            SequenceNumber sequenceNumber = db.SequenceNumbers.Find(id);
            if (sequenceNumber == null)
            {
                return NotFound();
            }

            db.SequenceNumbers.Remove(sequenceNumber);
            db.SaveChanges();

            return Ok(sequenceNumber);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SequenceNumberExists(int id)
        {
            return db.SequenceNumbers.Count(e => e.SequenceNumberId == id) > 0;
        }
    }
}