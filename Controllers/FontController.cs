using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FontController : ControllerBase
    {
        private readonly EchaContext _context;

        public FontController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/Font
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Font>>> GetFonts()
        {
            return await _context.Fonts.ToListAsync();
        }

        // GET: api/Font/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Font>> GetFont(int id)
        {
            var font = await _context.Fonts.FindAsync(id);

            if (font == null)
            {
                return NotFound();
            }

            return font;
        }

        // PUT: api/Font/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFont(int id, Font font)
        {
            if (id != font.Id)
            {
                return BadRequest();
            }

            _context.Entry(font).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FontExists(id))
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

        // POST: api/Font
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Font>> PostFont(Font font)
        {
            _context.Fonts.Add(font);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFont", new { id = font.Id }, font);
        }

        // DELETE: api/Font/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFont(int id)
        {
            var font = await _context.Fonts.FindAsync(id);
            if (font == null)
            {
                return NotFound();
            }

            _context.Fonts.Remove(font);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FontExists(int id)
        {
            return _context.Fonts.Any(e => e.Id == id);
        }
    }
}
