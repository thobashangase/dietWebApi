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
    public class RecommendedCalorieStepsController : ControllerBase
    {
        private readonly DietDbContext _context;

        public RecommendedCalorieStepsController(DietDbContext context)
        {
            _context = context;
        }

        // GET: api/RecommendedCalorieSteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecommendedCalorieSteps>>> GetRecommendedCalorieSteps()
        {
            return await _context.RecommendedCalorieSteps.ToListAsync();
        }

        // GET: api/RecommendedCalorieSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecommendedCalorieSteps>> GetRecommendedCalorieSteps(int id)
        {
            var recommendedCalorieSteps = await _context.RecommendedCalorieSteps.FindAsync(id);

            if (recommendedCalorieSteps == null)
            {
                return NotFound();
            }

            return recommendedCalorieSteps;
        }

        // PUT: api/RecommendedCalorieSteps/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecommendedCalorieSteps(int id, RecommendedCalorieSteps recommendedCalorieSteps)
        {
            if (id != recommendedCalorieSteps.Id)
            {
                return BadRequest();
            }

            _context.Entry(recommendedCalorieSteps).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecommendedCalorieStepsExists(id))
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

        // POST: api/RecommendedCalorieSteps
        [HttpPost]
        public async Task<ActionResult<RecommendedCalorieSteps>> PostRecommendedCalorieSteps(RecommendedCalorieSteps recommendedCalorieSteps)
        {
            _context.RecommendedCalorieSteps.Add(recommendedCalorieSteps);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecommendedCalorieSteps", new { id = recommendedCalorieSteps.Id }, recommendedCalorieSteps);
        }

        // DELETE: api/RecommendedCalorieSteps/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecommendedCalorieSteps>> DeleteRecommendedCalorieSteps(int id)
        {
            var recommendedCalorieSteps = await _context.RecommendedCalorieSteps.FindAsync(id);
            if (recommendedCalorieSteps == null)
            {
                return NotFound();
            }

            _context.RecommendedCalorieSteps.Remove(recommendedCalorieSteps);
            await _context.SaveChangesAsync();

            return recommendedCalorieSteps;
        }

        private bool RecommendedCalorieStepsExists(int id)
        {
            return _context.RecommendedCalorieSteps.Any(e => e.Id == id);
        }
    }
}
