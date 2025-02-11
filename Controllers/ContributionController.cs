using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionController : ControllerBase
    {
        private readonly EchaContext _context;

        public ContributionController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/Contribution
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribution>>> GetContributions()
        {
            return await _context.Contributions.ToListAsync();
        }

        // GET: api/Contribution/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contribution>> GetContribution(int id)
        {
            var contribution = await _context.Contributions.FindAsync(id);

            if (contribution == null)
            {
                return NotFound();
            }

            return contribution;
        }

        // PUT: api/Contribution/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContribution(int id, Contribution contribution)
        {
            if (id != contribution.Id)
            {
                return BadRequest();
            }

            var existingContibuion = await _context.Contributions
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (existingContibuion == null)
            {
                return NotFound();
            }

            contribution.CreationDate = existingContibuion.CreationDate;

            _context.Entry(contribution).State = EntityState.Modified;
            _context.Entry(contribution).Property(c => c.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributionExists(id))
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

        // POST: api/Contribution
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contribution>> PostContribution(Contribution contribution)
        {
            _context.Contributions.Add(contribution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContribution", new { id = contribution.Id }, contribution);
        }

        // DELETE: api/Contribution/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContribution(int id)
        {
            var contribution = await _context.Contributions.FindAsync(id);
            if (contribution == null)
            {
                return NotFound();
            }

            _context.Contributions.Remove(contribution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContributionExists(int id)
        {
            return _context.Contributions.Any(e => e.Id == id);
        }
    }
}
