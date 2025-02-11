using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusUserController : ControllerBase
    {
        private readonly EchaContext _context;

        public StatusUserController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/StatusUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusUser>>> GetStatusUsers()
        {
            return await _context.StatusUsers.ToListAsync();
        }

        // GET: api/StatusUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusUser>> GetStatusUser(int id)
        {
            var statusUser = await _context.StatusUsers.FindAsync(id);

            if (statusUser == null)
            {
                return NotFound();
            }

            return statusUser;
        }

        // PUT: api/StatusUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusUser(int id, StatusUser statusUser)
        {
            if (id != statusUser.Id)
            {
                return BadRequest();
            }

            var existingStatusUser = await _context.StatusUsers
                .AsNoTracking()
                .FirstOrDefaultAsync(su => su.Id == id);

            if (existingStatusUser == null)
            {
                return NotFound();
            }

            statusUser.CreationDate = existingStatusUser.CreationDate;

            _context.Entry(statusUser).State = EntityState.Modified;
            _context.Entry(statusUser).Property(su => su.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusUserExists(id))
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

        // POST: api/StatusUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusUser>> PostStatusUser(StatusUser statusUser)
        {
            _context.StatusUsers.Add(statusUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusUser", new { id = statusUser.Id }, statusUser);
        }

        // DELETE: api/StatusUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusUser(int id)
        {
            var statusUser = await _context.StatusUsers.FindAsync(id);
            if (statusUser == null)
            {
                return NotFound();
            }

            _context.StatusUsers.Remove(statusUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusUserExists(int id)
        {
            return _context.StatusUsers.Any(e => e.Id == id);
        }
    }
}
