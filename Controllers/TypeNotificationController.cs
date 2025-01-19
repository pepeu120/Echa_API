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
    public class TypeNotificationController : ControllerBase
    {
        private readonly EchaContext _context;

        public TypeNotificationController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/TypeNotification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeNotification>>> GetTypeNotifications()
        {
            return await _context.TypeNotifications.ToListAsync();
        }

        // GET: api/TypeNotification/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeNotification>> GetTypeNotification(int id)
        {
            var typeNotification = await _context.TypeNotifications.FindAsync(id);

            if (typeNotification == null)
            {
                return NotFound();
            }

            return typeNotification;
        }

        // PUT: api/TypeNotification/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeNotification(int id, TypeNotification typeNotification)
        {
            if (id != typeNotification.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeNotification).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeNotificationExists(id))
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

        // POST: api/TypeNotification
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeNotification>> PostTypeNotification(TypeNotification typeNotification)
        {
            _context.TypeNotifications.Add(typeNotification);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeNotification", new { id = typeNotification.Id }, typeNotification);
        }

        // DELETE: api/TypeNotification/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeNotification(int id)
        {
            var typeNotification = await _context.TypeNotifications.FindAsync(id);
            if (typeNotification == null)
            {
                return NotFound();
            }

            _context.TypeNotifications.Remove(typeNotification);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeNotificationExists(int id)
        {
            return _context.TypeNotifications.Any(e => e.Id == id);
        }
    }
}
