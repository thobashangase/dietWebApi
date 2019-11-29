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
    [Produces("application/json")]
    public class DailyDietsController : ControllerBase
    {
        private readonly DietDbContext _context;

        public DailyDietsController(DietDbContext context)
        {
            _context = context;
        }

        // GET: api/DailyDiets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyDiet>>> GetDailyDiets()
        {
            return await _context.DailyDiets.OrderBy(x => x.Day).ToListAsync();
        }

        // GET: api/DailyDiets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyDietDetailsViewModel>> GetDailyDiet(int id)
        {
            var dailyDiet = await _context.DailyDiets.FindAsync(id);

            if (dailyDiet == null)
            {
                return NotFound();
            }

            var rec = await _context.DailyDietRecommendations.Where(x => x.DailyDietId == dailyDiet.Id).FirstOrDefaultAsync();
            var recViewModel = new DailyDietRecommendationViewModel
            {
                Distance = rec.Distance, Steps = rec.Steps
            };

            var dailyDietViewModel = new DailyDietDetailsViewModel
            {
                Id = dailyDiet.Id,
                Day = dailyDiet.Day,
                TotalCalories = dailyDiet.TotalCalories,
                DailyDietRecommendations = recViewModel
            };

            return dailyDietViewModel;

            //var dailyDiet = await _context.DailyDiets.FindAsync(id);

            //if (dailyDiet == null)
            //{
            //    return NotFound();
            //}

            //return dailyDiet;
        }

        // PUT: api/DailyDiets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyDiet(int id, DailyDiet dailyDiet)
        {
            if (id != dailyDiet.Id)
            {
                return BadRequest();
            }

            _context.Entry(dailyDiet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyDietExists(id))
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

        // POST: api/DailyDiets
        [HttpPost]
        public async Task<ActionResult<DailyDiet>> PostDailyDiet([FromBody]AddDailyDietViewModel model)
        {
            var breakfast = _context.Meals.Find(model.Breakfast.MealId);
            var lunch = _context.Meals.Find(model.Lunch.MealId);
            var dinner = _context.Meals.Find(model.Dinner.MealId);

            int totalCalories = breakfast.Calories + lunch.Calories + dinner.Calories;

            var bDesert = _context.Deserts.Find(model.Breakfast.DesertId);

            if (bDesert != null)
                totalCalories += bDesert.Calories;

            var lDesert = _context.Deserts.Find(model.Lunch.DesertId);

            if (lDesert != null)
                totalCalories += lDesert.Calories;

            var dDesert = _context.Deserts.Find(model.Dinner.DesertId);

            if (dDesert != null)
                totalCalories += dDesert.Calories;

            DailyDiet dailyDiet = new DailyDiet
            {
                Day = model.Day, 
                TotalCalories = totalCalories
            };
            _context.DailyDiets.Add(dailyDiet);
            await _context.SaveChangesAsync();

            try
            {
                _context.DailyDietLines.Add(new DailyDietLine 
                { 
                    DailyDietId = dailyDiet.Id, 
                    DesertId = model.Breakfast.DesertId, 
                    MealId = model.Breakfast.MealId
                });

                _context.DailyDietLines.Add(new DailyDietLine
                {
                    DailyDietId = dailyDiet.Id,
                    DesertId = model.Lunch.DesertId,
                    MealId = model.Lunch.MealId
                });

                _context.DailyDietLines.Add(new DailyDietLine
                {
                    DailyDietId = dailyDiet.Id,
                    DesertId = model.Dinner.DesertId,
                    MealId = model.Dinner.MealId
                });

                DailyDietRecommendation dailyDietRecommendation = new DailyDietRecommendation
                {
                    DailyDietId = dailyDiet.Id,
                    Distance = Helpers.Helpers.CalculateDistance(dailyDiet.TotalCalories),
                    Steps = Helpers.Helpers.CalculateSteps(dailyDiet.TotalCalories)
                };
                _context.DailyDietRecommendations.Add(dailyDietRecommendation);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            //return CreatedAtAction("GetDailyDiet", new { id = dailyDiet.Id }, dailyDiet);
            return NoContent();
        }

        // DELETE: api/DailyDiets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DailyDiet>> DeleteDailyDiet(int id)
        {
            var dailyDiet = await _context.DailyDiets.FindAsync(id);
            if (dailyDiet == null)
            {
                return NotFound();
            }

            //recs
            var dailyDietRecs = await _context.DailyDietRecommendations.Where(x => x.DailyDietId == dailyDiet.Id).ToListAsync();

            if (dailyDietRecs != null || dailyDietRecs.Count() > 0)
            {
                foreach (var i in dailyDietRecs)
                {
                    _context.Remove(i);
                }
            }

            //diet lines
            var dailyDietLines = await _context.DailyDietLines.Where(x => x.DailyDietId == dailyDiet.Id).ToListAsync();

            if (dailyDietLines != null || dailyDietLines.Count() > 0)
            {
                foreach (var i in dailyDietLines)
                {
                    _context.Remove(i);
                }
            }

            //diet
            _context.DailyDiets.Remove(dailyDiet);

            await _context.SaveChangesAsync();

            return dailyDiet;
        }

        private bool DailyDietExists(int id)
        {
            return _context.DailyDiets.Any(e => e.Id == id);
        }
    }
}
