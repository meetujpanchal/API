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
    public class OrdersTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public OrdersTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/OrdersTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdersTbl>>> GetOrdersTbls()
        {
          if (_context.OrdersTbls == null)
          {
              return NotFound();
          }
            return await _context.OrdersTbls.ToListAsync();
        }

        // GET: api/OrdersTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersTbl>> GetOrdersTbl(int id)
        {
          if (_context.OrdersTbls == null)
          {
              return NotFound();
          }
            var ordersTbl = await _context.OrdersTbls.FindAsync(id);

            if (ordersTbl == null)
            {
                return NotFound();
            }

            return ordersTbl;
        }

        // PUT: api/OrdersTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdersTbl(int id, OrdersTbl ordersTbl)
        {
            if (id != ordersTbl.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(ordersTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersTblExists(id))
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

        // POST: api/OrdersTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrdersTbl>> PostOrdersTbl(OrdersTbl ordersTbl)
        {
          if (_context.OrdersTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.OrdersTbls'  is null.");
          }
            _context.OrdersTbls.Add(ordersTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdersTbl", new { id = ordersTbl.OrderId }, ordersTbl);
        }

        // DELETE: api/OrdersTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdersTbl(int id)
        {
            if (_context.OrdersTbls == null)
            {
                return NotFound();
            }
            var ordersTbl = await _context.OrdersTbls.FindAsync(id);
            if (ordersTbl == null)
            {
                return NotFound();
            }

            _context.OrdersTbls.Remove(ordersTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdersTblExists(int id)
        {
            return (_context.OrdersTbls?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
