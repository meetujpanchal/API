using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpticartWebAPI.Models;

namespace OpticartWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public PaymentTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTbl>>> GetPaymentTbls()
        {
          if (_context.PaymentTbls == null)
          {
              return NotFound();
          }
            return await _context.PaymentTbls.ToListAsync();
        }

        // GET: api/PaymentTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTbl>> GetPaymentTbl(int id)
        {
          if (_context.PaymentTbls == null)
          {
              return NotFound();
          }
            var paymentTbl = await _context.PaymentTbls.FindAsync(id);

            if (paymentTbl == null)
            {
                return NotFound();
            }

            return paymentTbl;
        }

        // PUT: api/PaymentTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTbl(int id, PaymentTbl paymentTbl)
        {
            if (id != paymentTbl.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(paymentTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTblExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymentTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTbl>> PostPaymentTbl(PaymentTbl paymentTbl)
        {
          if (_context.PaymentTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.PaymentTbls'  is null.");
          }
            _context.PaymentTbls.Add(paymentTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTbl", new { id = paymentTbl.PaymentId }, paymentTbl);
        }

        // DELETE: api/PaymentTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTbl(int id)
        {
            if (_context.PaymentTbls == null)
            {
                return NotFound();
            }
            var paymentTbl = await _context.PaymentTbls.FindAsync(id);
            if (paymentTbl == null)
            {
                return NotFound();
            }

            _context.PaymentTbls.Remove(paymentTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTblExists(int id)
        {
            return (_context.PaymentTbls?.Any(e => e.PaymentId == id)).GetValueOrDefault();
        }
    }
}
