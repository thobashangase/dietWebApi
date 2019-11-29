using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dietapi.Models;

namespace dietapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendedStepsDistancesController : ControllerBase
    {
        private readonly DietDbContext _context;

        public RecommendedStepsDistancesController(DietDbContext context)
        {
            _context = context;
        }

        // GET: api/RecommendedStepsDistances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecommendedStepsDistance>>> GetRecommendedStepsDistances()
        {
            return await _context.RecommendedStepsDistances.ToListAsync();
        }

        // GET: api/RecommendedStepsDistances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecommendedStepsDistance>> GetRecommendedStepsDistance(int id)
        {
            var recommendedStepsDistance = await _context.RecommendedStepsDistances.FindAsync(id);

            if (recommendedStepsDistance == null)
            {
                return NotFound();
            }

            return recommendedStepsDistance;
        }

        // PUT: api/RecommendedStepsDistances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecommendedStepsDistance(int id, RecommendedStepsDistance recommendedStepsDistance)
        {
            if (id != recommendedStepsDistance.Id)
            {
                return BadRequest();
            }

            _context.Entry(recommendedStepsDistance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecommendedStepsDistanceExists(id))
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

        // POST: api/RecommendedStepsDistances
        [HttpPost]
        public async Task<ActionResult<RecommendedStepsDistance>> PostRecommendedStepsDistance(RecommendedStepsDistance recommendedStepsDistance)
        {
            _context.RecommendedStepsDistances.Add(recommendedStepsDistance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecommendedStepsDistance", new { id = recommendedStepsDistance.Id }, recommendedStepsDistance);
        }

        // DELETE: api/RecommendedStepsDistances/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecommendedStepsDistance>> DeleteRecommendedStepsDistance(int id)
        {
            var recommendedStepsDistance = await _context.RecommendedStepsDistances.FindAsync(id);
            if (recommendedStepsDistance == null)
            {
                return NotFound();
            }

            _context.RecommendedStepsDistances.Remove(recommendedStepsDistance);
            await _context.SaveChangesAsync();

            return recommendedStepsDistance;
        }

        private bool RecommendedStepsDistanceExists(int id)
        {
            return _context.RecommendedStepsDistances.Any(e => e.Id == id);
        }
    }
}
