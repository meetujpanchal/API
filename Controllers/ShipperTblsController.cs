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
    public class ShipperTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public ShipperTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/ShipperTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipperTbl>>> GetShipperTbls()
        {
          if (_context.ShipperTbls == null)
          {
              return NotFound();
          }
            return await _context.ShipperTbls.ToListAsync();
        }

        // GET: api/ShipperTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipperTbl>> GetShipperTbl(int id)
        {
          if (_context.ShipperTbls == null)
          {
              return NotFound();
          }
            var shipperTbl = await _context.ShipperTbls.FindAsync(id);

            if (shipperTbl == null)
            {
                return NotFound();
            }

            return shipperTbl;
        }

        // PUT: api/ShipperTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipperTbl(int id, ShipperTbl shipperTbl)
        {
            if (id != shipperTbl.ShipperId)
            {
                return BadRequest();
            }

            _context.Entry(shipperTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipperTblExists(id))
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

        // POST: api/ShipperTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShipperTbl>> PostShipperTbl(ShipperTbl shipperTbl)
        {
          if (_context.ShipperTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.ShipperTbls'  is null.");
          }
            _context.ShipperTbls.Add(shipperTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipperTbl", new { id = shipperTbl.ShipperId }, shipperTbl);
        }

        // DELETE: api/ShipperTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipperTbl(int id)
        {
            if (_context.ShipperTbls == null)
            {
                return NotFound();
            }
            var shipperTbl = await _context.ShipperTbls.FindAsync(id);
            if (shipperTbl == null)
            {
                return NotFound();
            }

            _context.ShipperTbls.Remove(shipperTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipperTblExists(int id)
        {
            return (_context.ShipperTbls?.Any(e => e.ShipperId == id)).GetValueOrDefault();
        }
    }
}
