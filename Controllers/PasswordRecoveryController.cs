using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoveryController : ControllerBase
    {
        private readonly EchaContext _context;

        public PasswordRecoveryController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/PasswordRecovery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PasswordRecovery>>> GetPasswordRecoveries()
        {
            return await _context.PasswordRecoveries.ToListAsync();
        }

        // GET: api/PasswordRecovery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PasswordRecovery>> GetPasswordRecovery(int id)
        {
            var passwordRecovery = await _context.PasswordRecoveries
                .Include(pr => pr.User)
                .SingleOrDefaultAsync(pr => pr.Id == id);

            if (passwordRecovery == null)
            {
                return NotFound();
            }

            return passwordRecovery;
        }

        // PUT: api/PasswordRecovery/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasswordRecovery(int id, PasswordRecovery passwordRecovery)
        {
            if (id != passwordRecovery.Id)
            {
                return BadRequest();
            }

            var existingPasswordRecovery = await _context.PasswordRecoveries
                .AsNoTracking()
                .FirstOrDefaultAsync(pr => pr.Id == id);

            if (existingPasswordRecovery == null)
            {
                return NotFound();
            }

            passwordRecovery.CreationDate = existingPasswordRecovery.CreationDate;

            _context.Entry(passwordRecovery).State = EntityState.Modified;
            _context.Entry(passwordRecovery).Property(pr => pr.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasswordRecoveryExists(id))
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

        // POST: api/PasswordRecovery
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PasswordRecovery>> PostPasswordRecovery(PasswordRecovery passwordRecovery)
        {
            _context.PasswordRecoveries.Add(passwordRecovery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasswordRecovery", new { id = passwordRecovery.Id }, passwordRecovery);
        }

        // DELETE: api/PasswordRecovery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasswordRecovery(int id)
        {
            var passwordRecovery = await _context.PasswordRecoveries.FindAsync(id);
            if (passwordRecovery == null)
            {
                return NotFound();
            }

            _context.PasswordRecoveries.Remove(passwordRecovery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasswordRecoveryExists(int id)
        {
            return _context.PasswordRecoveries.Any(e => e.Id == id);
        }
    }
}
