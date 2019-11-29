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
    public class DailyDietRecommendationsController : ControllerBase
    {
        private readonly DietDbContext _context;

        public DailyDietRecommendationsController(DietDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyDietRecommendations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyDietRecommendation>>> GetDailyDietRecommendations()
        {
            return await _context.DailyDietRecommendations.ToListAsync();
        }

        // GET: api/DailyDietRecommendations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyDietRecommendation>> GetDailyDietRecommendation(int id)
        {
            var dailyDietRecommendation = await _context.DailyDietRecommendations.FindAsync(id);

            if (dailyDietRecommendation == null)
            {
                return NotFound();
            }

            return dailyDietRecommendation;
        }

        // PUT: api/DailyDietRecommendations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyDietRecommendation(int id, DailyDietRecommendation dailyDietRecommendation)
        {
            if (id != dailyDietRecommendation.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyDietRecommendation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyDietRecommendationExists(id))
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

        // POST: api/DailyDietRecommendations
        [HttpPost]
        public async Task<ActionResult<DailyDietRecommendation>> PostDailyDietRecommendation([FromBody]DailyDietRecommendation dailyDietRecommendation)
        {
            _context.DailyDietRecommendations.Add(dailyDietRecommendation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDailyDietRecommendation", new { id = dailyDietRecommendation.Id }, dailyDietRecommendation);
        }

        // DELETE: api/DailyDietRecommendations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyDietRecommendation>> DeleteDailyDietRecommendation(int id)
        {
            var dailyDietRecommendation = await _context.DailyDietRecommendations.FindAsync(id);
            if (dailyDietRecommendation == null)
            {
                return NotFound();
            }

            _context.DailyDietRecommendations.Remove(dailyDietRecommendation);
            await _context.SaveChangesAsync();

            return dailyDietRecommendation;
        }

        private bool DailyDietRecommendationExists(int id)
        {
            return _context.DailyDietRecommendations.Any(e => e.Id == id);
        }
    }
}
