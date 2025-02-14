using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusItemController : ControllerBase
    {
        private readonly EchaContext _context;

        public StatusItemController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/StatusItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusItem>>> GetStatusItems()
        {
            return await _context.StatusItems.ToListAsync();
        }

        // GET: api/StatusItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusItem>> GetStatusItem(int id)
        {
            var statusItem = await _context.StatusItems
                .Include(si => si.Items)
                .SingleOrDefaultAsync(si => si.Id == id);

            if (statusItem == null)
            {
                return NotFound();
            }

            return statusItem;
        }

        // PUT: api/StatusItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusItem(int id, StatusItem statusItem)
        {
            if (id != statusItem.Id)
            {
                return BadRequest();
            }

            var existingStatusItem = await _context.StatusItems
                .AsNoTracking()
                .FirstOrDefaultAsync(si => si.Id == id);

            if (existingStatusItem == null)
            {
                return NotFound();
            }

            statusItem.CreationDate = existingStatusItem.CreationDate;

            _context.Entry(statusItem).State = EntityState.Modified;
            _context.Entry(statusItem).Property(si => si.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusItemExists(id))
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

        // POST: api/StatusItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusItem>> PostStatusItem(StatusItem statusItem)
        {
            _context.StatusItems.Add(statusItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusItem", new { id = statusItem.Id }, statusItem);
        }

        // DELETE: api/StatusItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusItem(int id)
        {
            var statusItem = await _context.StatusItems.FindAsync(id);
            if (statusItem == null)
            {
                return NotFound();
            }

            _context.StatusItems.Remove(statusItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusItemExists(int id)
        {
            return _context.StatusItems.Any(e => e.Id == id);
        }
    }
}
