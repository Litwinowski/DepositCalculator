using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebDepositCalculator.Models;

namespace WebDepositCalculator.Controllers
{
    public class CalculatorsController : ApiController
    {
        private WebDepositCalculatorContext db = new WebDepositCalculatorContext();

        // GET api/Calculators
        public IQueryable<Calculator> GetCalculators()
        {
            return db.Calculators;
        }

        // GET api/Calculators/5
        [ResponseType(typeof(Calculator))]
        public async Task<IHttpActionResult> GetCalculator(int id)
        {
            Calculator calculator = await db.Calculators.FindAsync(id);
            if (calculator == null)
            {
                return NotFound();
            }

            return Ok(calculator);
        }

        // PUT api/Calculators/5
        public async Task<IHttpActionResult> PutCalculator(int id, Calculator calculator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calculator.ID)
            {
                return BadRequest();
            }

            db.Entry(calculator).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculatorExists(id))
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

        // POST api/Calculators
        [ResponseType(typeof(Calculator))]
        public async Task<IHttpActionResult> PostCalculator(Calculator calculator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calculators.Add(calculator);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = calculator.ID }, calculator);
        }

        // DELETE api/Calculators/5
        [ResponseType(typeof(Calculator))]
        public async Task<IHttpActionResult> DeleteCalculator(int id)
        {
            Calculator calculator = await db.Calculators.FindAsync(id);
            if (calculator == null)
            {
                return NotFound();
            }

            db.Calculators.Remove(calculator);
            await db.SaveChangesAsync();

            return Ok(calculator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CalculatorExists(int id)
        {
            return db.Calculators.Count(e => e.ID == id) > 0;
        }
    }
}