using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P6_APPI_CAROLINAR.Models;

namespace P6_APPI_CAROLINAR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelsController : ControllerBase
    {
        private readonly P620242travelsContext _context;

        public TravelsController(P620242travelsContext context)
        {
            _context = context;
        }

        // GET: api/Travels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Travel>>> GetTravels()
        {
            return await _context.Travels.ToListAsync();
        }

        // GET: api/Travels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Travel>> GetTravel(int id)
        {
            var travel = await _context.Travels.FindAsync(id);

            if (travel == null)
            {
                return NotFound();
            }

            return travel;
        }

        // PUT: api/Travels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravel(int id, Travel travel)
        {
            if (id != travel.TravelId)
            {
                return BadRequest();
            }

            _context.Entry(travel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelExists(id))
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

        // POST: api/Travels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Travel>> PostTravel(Travel travel)
        {
            _context.Travels.Add(travel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravel", new { id = travel.TravelId }, travel);
        }

        // DELETE: api/Travels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravel(int id)
        {
            var travel = await _context.Travels.FindAsync(id);
            if (travel == null)
            {
                return NotFound();
            }

            _context.Travels.Remove(travel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelExists(int id)
        {
            return _context.Travels.Any(e => e.TravelId == id);
        }
    }
}
