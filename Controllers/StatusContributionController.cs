using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusContributionController : ControllerBase
    {
        private readonly EchaContext _context;

        public StatusContributionController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/StatusContribution
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusContribution>>> GetStatusContributions()
        {
            return await _context.StatusContributions.ToListAsync();
        }

        // GET: api/StatusContribution/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusContribution>> GetStatusContribution(int id)
        {
            var statusContribution = await _context.StatusContributions
                .Include(sc => sc.Contributions)
                .SingleOrDefaultAsync(sc => sc.Id == id);

            if (statusContribution == null)
            {
                return NotFound();
            }

            return statusContribution;
        }

        // PUT: api/StatusContribution/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusContribution(int id, StatusContribution statusContribution)
        {
            if (id != statusContribution.Id)
            {
                return BadRequest();
            }

            var existingStatusContribution = await _context.StatusContributions
                .AsNoTracking()
                .FirstOrDefaultAsync(sc => sc.Id == id);

            if (existingStatusContribution == null)
            {
                return NotFound();
            }

            statusContribution.CreationDate = existingStatusContribution.CreationDate;

            _context.Entry(statusContribution).State = EntityState.Modified;
            _context.Entry(statusContribution).Property(sc => sc.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusContributionExists(id))
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

        // POST: api/StatusContribution
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusContribution>> PostStatusContribution(StatusContribution statusContribution)
        {
            _context.StatusContributions.Add(statusContribution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusContribution", new { id = statusContribution.Id }, statusContribution);
        }

        // DELETE: api/StatusContribution/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusContribution(int id)
        {
            var statusContribution = await _context.StatusContributions.FindAsync(id);
            if (statusContribution == null)
            {
                return NotFound();
            }

            _context.StatusContributions.Remove(statusContribution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusContributionExists(int id)
        {
            return _context.StatusContributions.Any(e => e.Id == id);
        }
    }
}
