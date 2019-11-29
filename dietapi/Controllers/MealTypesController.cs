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
    public class MealTypesController : ControllerBase
    {
        private readonly DietDbContext _context;

        public MealTypesController(DietDbContext context)
        {
            _context = context;
        }

        // GET: api/MealTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealType>>> GetMealTypes()
        {
            return await _context.MealTypes.ToListAsync();
        }

        // GET: api/MealTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealType>> GetMealType(int id)
        {
            var mealType = await _context.MealTypes.FindAsync(id);

            if (mealType == null)
            {
                return NotFound();
            }

            return mealType;
        }

        // PUT: api/MealTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealType(int id, MealType mealType)
        {
            if (id != mealType.Id)
            {
                return BadRequest();
            }

            _context.Entry(mealType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealTypeExists(id))
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

        // POST: api/MealTypes
        [HttpPost]
        public async Task<ActionResult<MealType>> PostMealType(MealType mealType)
        {
            _context.MealTypes.Add(mealType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealType", new { id = mealType.Id }, mealType);
        }

        // DELETE: api/MealTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MealType>> DeleteMealType(int id)
        {
            var mealType = await _context.MealTypes.FindAsync(id);
            if (mealType == null)
            {
                return NotFound();
            }

            _context.MealTypes.Remove(mealType);
            await _context.SaveChangesAsync();

            return mealType;
        }

        private bool MealTypeExists(int id)
        {
            return _context.MealTypes.Any(e => e.Id == id);
        }
    }
}
