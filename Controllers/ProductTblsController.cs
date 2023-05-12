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
    public class ProductTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public ProductTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTbl>>> GetProductTbls()
        {
          if (_context.ProductTbls == null)
          {
              return NotFound();
          }
            return await _context.ProductTbls.ToListAsync();
        }

        // GET: api/ProductTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTbl>> GetProductTbl(int id)
        {
          if (_context.ProductTbls == null)
          {
              return NotFound();
          }
            var productTbl = await _context.ProductTbls.FindAsync(id);

            if (productTbl == null)
            {
                return NotFound();
            }

            return productTbl;
        }

        // PUT: api/ProductTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductTbl(int id, ProductTbl productTbl)
        {
            if (id != productTbl.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(productTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTblExists(id))
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

        // POST: api/ProductTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductTbl>> PostProductTbl(ProductTbl productTbl)
        {
          if (_context.ProductTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.ProductTbls'  is null.");
          }
            _context.ProductTbls.Add(productTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductTbl", new { id = productTbl.ProductId }, productTbl);
        }

        // DELETE: api/ProductTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductTbl(int id)
        {
            if (_context.ProductTbls == null)
            {
                return NotFound();
            }
            var productTbl = await _context.ProductTbls.FindAsync(id);
            if (productTbl == null)
            {
                return NotFound();
            }

            _context.ProductTbls.Remove(productTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTblExists(int id)
        {
            return (_context.ProductTbls?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
