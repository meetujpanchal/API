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
    public class CategoryTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public CategoryTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/CategoryTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryTbl>>> GetCategoryTbls()
        {
          if (_context.CategoryTbls == null)
          {
              return NotFound();
          }
            return await _context.CategoryTbls.ToListAsync();
        }

        // GET: api/CategoryTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryTbl>> GetCategoryTbl(int id)
        {
          if (_context.CategoryTbls == null)
          {
              return NotFound();
          }
            var categoryTbl = await _context.CategoryTbls.FindAsync(id);

            if (categoryTbl == null)
            {
                return NotFound();
            }

            return categoryTbl;
        }

        // PUT: api/CategoryTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryTbl(int id, CategoryTbl categoryTbl)
        {
            if (id != categoryTbl.CategoryId)
            {
                return BadRequest();
            }

            _context.Entry(categoryTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryTblExists(id))
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

        // POST: api/CategoryTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryTbl>> PostCategoryTbl(CategoryTbl categoryTbl)
        {
          if (_context.CategoryTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.CategoryTbls'  is null.");
          }
            _context.CategoryTbls.Add(categoryTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoryTbl", new { id = categoryTbl.CategoryId }, categoryTbl);
        }

        // DELETE: api/CategoryTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryTbl(int id)
        {
            if (_context.CategoryTbls == null)
            {
                return NotFound();
            }
            var categoryTbl = await _context.CategoryTbls.FindAsync(id);
            if (categoryTbl == null)
            {
                return NotFound();
            }

            _context.CategoryTbls.Remove(categoryTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryTblExists(int id)
        {
            return (_context.CategoryTbls?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }
    }
}
