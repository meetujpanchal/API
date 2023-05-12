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
    public class FeedbackTblsController : ControllerBase
    {
        private readonly OptiCartDbContext _context;

        public FeedbackTblsController(OptiCartDbContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackTbl>>> GetFeedbackTbls()
        {
          if (_context.FeedbackTbls == null)
          {
              return NotFound();
          }
            return await _context.FeedbackTbls.ToListAsync();
        }

        // GET: api/FeedbackTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackTbl>> GetFeedbackTbl(int id)
        {
          if (_context.FeedbackTbls == null)
          {
              return NotFound();
          }
            var feedbackTbl = await _context.FeedbackTbls.FindAsync(id);

            if (feedbackTbl == null)
            {
                return NotFound();
            }

            return feedbackTbl;
        }

        // PUT: api/FeedbackTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbackTbl(int id, FeedbackTbl feedbackTbl)
        {
            if (id != feedbackTbl.FdId)
            {
                return BadRequest();
            }

            _context.Entry(feedbackTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackTblExists(id))
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

        // POST: api/FeedbackTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FeedbackTbl>> PostFeedbackTbl(FeedbackTbl feedbackTbl)
        {
          if (_context.FeedbackTbls == null)
          {
              return Problem("Entity set 'OptiCartDbContext.FeedbackTbls'  is null.");
          }
            _context.FeedbackTbls.Add(feedbackTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFeedbackTbl", new { id = feedbackTbl.FdId }, feedbackTbl);
        }

        // DELETE: api/FeedbackTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedbackTbl(int id)
        {
            if (_context.FeedbackTbls == null)
            {
                return NotFound();
            }
            var feedbackTbl = await _context.FeedbackTbls.FindAsync(id);
            if (feedbackTbl == null)
            {
                return NotFound();
            }

            _context.FeedbackTbls.Remove(feedbackTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FeedbackTblExists(int id)
        {
            return (_context.FeedbackTbls?.Any(e => e.FdId == id)).GetValueOrDefault();
        }
    }
}
