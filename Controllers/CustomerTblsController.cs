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
    public class CustomerTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public CustomerTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerTbl>>> GetCustomerTbls()
        {
          if (_context.CustomerTbls == null)
          {
              return NotFound();
          }
            return await _context.CustomerTbls.ToListAsync();
        }

        // GET: api/CustomerTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerTbl>> GetCustomerTbl(int id)
        {
          if (_context.CustomerTbls == null)
          {
              return NotFound();
          }
            var customerTbl = await _context.CustomerTbls.FindAsync(id);

            if (customerTbl == null)
            {
                return NotFound();
            }

            return customerTbl;
        }

        // PUT: api/CustomerTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerTbl(int id, CustomerTbl customerTbl)
        {
            if (id != customerTbl.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerTblExists(id))
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

        // POST: api/CustomerTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerTbl>> PostCustomerTbl(CustomerTbl customerTbl)
        {
          if (_context.CustomerTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.CustomerTbls'  is null.");
          }
            _context.CustomerTbls.Add(customerTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerTbl", new { id = customerTbl.CustomerId }, customerTbl);
        }

        // DELETE: api/CustomerTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerTbl(int id)
        {
            if (_context.CustomerTbls == null)
            {
                return NotFound();
            }
            var customerTbl = await _context.CustomerTbls.FindAsync(id);
            if (customerTbl == null)
            {
                return NotFound();
            }

            _context.CustomerTbls.Remove(customerTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerTblExists(int id)
        {
            return (_context.CustomerTbls?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
