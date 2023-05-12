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
    public class VendorTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public VendorTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/VendorTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorTbl>>> GetVendorTbls()
        {
          if (_context.VendorTbls == null)
          {
              return NotFound();
          }
            return await _context.VendorTbls.ToListAsync();
        }

        // GET: api/VendorTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorTbl>> GetVendorTbl(int id)
        {
          if (_context.VendorTbls == null)
          {
              return NotFound();
          }
            var vendorTbl = await _context.VendorTbls.FindAsync(id);

            if (vendorTbl == null)
            {
                return NotFound();
            }

            return vendorTbl;
        }

        // PUT: api/VendorTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorTbl(int id, VendorTbl vendorTbl)
        {
            if (id != vendorTbl.VendorId)
            {
                return BadRequest();
            }

            _context.Entry(vendorTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorTblExists(id))
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

        // POST: api/VendorTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendorTbl>> PostVendorTbl(VendorTbl vendorTbl)
        {
          if (_context.VendorTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.VendorTbls'  is null.");
          }
            _context.VendorTbls.Add(vendorTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorTbl", new { id = vendorTbl.VendorId }, vendorTbl);
        }

        // DELETE: api/VendorTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorTbl(int id)
        {
            if (_context.VendorTbls == null)
            {
                return NotFound();
            }
            var vendorTbl = await _context.VendorTbls.FindAsync(id);
            if (vendorTbl == null)
            {
                return NotFound();
            }

            _context.VendorTbls.Remove(vendorTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorTblExists(int id)
        {
            return (_context.VendorTbls?.Any(e => e.VendorId == id)).GetValueOrDefault();
        }
    }
}
