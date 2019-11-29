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
    public class DesertsController : ControllerBase
    {
        private readonly DietDbContext _context;

        public DesertsController(DietDbContext context)
        {
            _context = context;
        }

        // GET: api/Deserts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desert>>> GetDeserts()
        {
            return await _context.Deserts.ToListAsync();
        }

        // GET: api/Deserts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desert>> GetDesert(int id)
        {
            var desert = await _context.Deserts.FindAsync(id);

            if (desert == null)
            {
                return NotFound();
            }

            return desert;
        }

        // PUT: api/Deserts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesert(int id, Desert desert)
        {
            if (id != desert.Id)
            {
                return BadRequest();
            }

            _context.Entry(desert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesertExists(id))
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

        // POST: api/Deserts
        [HttpPost]
        public async Task<ActionResult<Desert>> PostDesert(Desert desert)
        {
            _context.Deserts.Add(desert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesert", new { id = desert.Id }, desert);
        }

        // DELETE: api/Deserts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Desert>> DeleteDesert(int id)
        {
            var desert = await _context.Deserts.FindAsync(id);
            if (desert == null)
            {
                return NotFound();
            }

            _context.Deserts.Remove(desert);
            await _context.SaveChangesAsync();

            return desert;
        }

        private bool DesertExists(int id)
        {
            return _context.Deserts.Any(e => e.Id == id);
        }
    }
}
