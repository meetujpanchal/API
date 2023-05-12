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
    public class OrderDetailsTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public OrderDetailsTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetailsTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetailsTbl>>> GetOrderDetailsTbls()
        {
          if (_context.OrderDetailsTbls == null)
          {
              return NotFound();
          }
            return await _context.OrderDetailsTbls.ToListAsync();
        }

        // GET: api/OrderDetailsTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetailsTbl>> GetOrderDetailsTbl(int id)
        {
          if (_context.OrderDetailsTbls == null)
          {
              return NotFound();
          }
            var orderDetailsTbl = await _context.OrderDetailsTbls.FindAsync(id);

            if (orderDetailsTbl == null)
            {
                return NotFound();
            }

            return orderDetailsTbl;
        }

        // PUT: api/OrderDetailsTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetailsTbl(int id, OrderDetailsTbl orderDetailsTbl)
        {
            if (id != orderDetailsTbl.OrderDetailId)
            {
                return BadRequest();
            }

            _context.Entry(orderDetailsTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailsTblExists(id))
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

        // POST: api/OrderDetailsTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetailsTbl>> PostOrderDetailsTbl(OrderDetailsTbl orderDetailsTbl)
        {
          if (_context.OrderDetailsTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.OrderDetailsTbls'  is null.");
          }
            _context.OrderDetailsTbls.Add(orderDetailsTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderDetailsTbl", new { id = orderDetailsTbl.OrderDetailId }, orderDetailsTbl);
        }

        // DELETE: api/OrderDetailsTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetailsTbl(int id)
        {
            if (_context.OrderDetailsTbls == null)
            {
                return NotFound();
            }
            var orderDetailsTbl = await _context.OrderDetailsTbls.FindAsync(id);
            if (orderDetailsTbl == null)
            {
                return NotFound();
            }

            _context.OrderDetailsTbls.Remove(orderDetailsTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderDetailsTblExists(int id)
        {
            return (_context.OrderDetailsTbls?.Any(e => e.OrderDetailId == id)).GetValueOrDefault();
        }
    }
}
