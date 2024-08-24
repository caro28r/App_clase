using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P6Travels_API_AllanDelgado.Models;

namespace P6Travels_API_AllanDelgado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostingsController : ControllerBase
    {
        private readonly P620242travelsContext _context;

        public HostingsController(P620242travelsContext context)
        {
            _context = context;
        }

        // GET: api/Hostings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hosting>>> GetHostings()
        {
            return await _context.Hostings.ToListAsync();
        }

        // GET: api/Hostings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hosting>> GetHosting(int id)
        {
            var hosting = await _context.Hostings.FindAsync(id);

            if (hosting == null)
            {
                return NotFound();
            }

            return hosting;
        }

        // PUT: api/Hostings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHosting(int id, Hosting hosting)
        {
            if (id != hosting.HostingId)
            {
                return BadRequest();
            }

            _context.Entry(hosting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HostingExists(id))
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

        // POST: api/Hostings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hosting>> PostHosting(Hosting hosting)
        {
            _context.Hostings.Add(hosting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHosting", new { id = hosting.HostingId }, hosting);
        }

        // DELETE: api/Hostings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHosting(int id)
        {
            var hosting = await _context.Hostings.FindAsync(id);
            if (hosting == null)
            {
                return NotFound();
            }

            _context.Hostings.Remove(hosting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HostingExists(int id)
        {
            return _context.Hostings.Any(e => e.HostingId == id);
        }
    }
}
