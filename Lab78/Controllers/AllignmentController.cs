using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab78.Data;
using Lab78.Models;

namespace Lab78.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllignmentController : ControllerBase
    {
        private readonly DBContext _context;

        public AllignmentController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Allignment
        [HttpGet, Route("Get")]
        public async Task<ActionResult<IEnumerable<Allignment>>> GetAllignments()
        {
            return await _context.Allignments.ToListAsync();
        }

        // GET: api/Allignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Allignment>> GetAllignment(int? id)
        {
            var allignment = await _context.Allignments.FindAsync(id);

            if (allignment == null)
            {
                return NotFound();
            }

            return allignment;
        }

        // PUT: api/Allignment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllignment(int? id, Allignment allignment)
        {
            if (id != allignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(allignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AllignmentExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/Allignment
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Allignment>> PostAllignment(Allignment allignment)
        {
          if (_context.Allignments == null)
          {
              return Problem("Entity set 'DBContext.Allignments'  is null.");
          }
          _context.Allignments.Add(allignment);
          await _context.SaveChangesAsync();

          return CreatedAtAction("GetAllignment", new { id = allignment.Id }, allignment);
        }

        // DELETE: api/Allignment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllignment(int? id)
        {
            if (_context.Allignments == null)
            {
                return NotFound();
            }
            var allignment = await _context.Allignments.FindAsync(id);
            if (allignment == null)
            {
                return NotFound();
            }

            _context.Allignments.Remove(allignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AllignmentExists(int? id)
        {
            return (_context.Allignments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
