using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusListController : ControllerBase
    {
        private readonly EchaContext _context;

        public StatusListController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/StatusList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusList>>> GetStatusLists()
        {
            return await _context.StatusLists.ToListAsync();
        }

        // GET: api/StatusList/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusList>> GetStatusList(int id)
        {
            var statusList = await _context.StatusLists
                .Include(sl => sl.Lists)
                .SingleOrDefaultAsync(sl => sl.Id == id);

            if (statusList == null)
            {
                return NotFound();
            }

            return statusList;
        }

        // PUT: api/StatusList/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusList(int id, StatusList statusList)
        {
            if (id != statusList.Id)
            {
                return BadRequest();
            }

            var existingStatusList = await _context.StatusLists
                .AsNoTracking()
                .FirstOrDefaultAsync(sl => sl.Id == id);

            if (existingStatusList == null)
            {
                return NotFound();
            }

            statusList.CreationDate = existingStatusList.CreationDate;

            _context.Entry(statusList).State = EntityState.Modified;
            _context.Entry(statusList).Property(sl => sl.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusListExists(id))
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

        // POST: api/StatusList
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusList>> PostStatusList(StatusList statusList)
        {
            _context.StatusLists.Add(statusList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusList", new { id = statusList.Id }, statusList);
        }

        // DELETE: api/StatusList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusList(int id)
        {
            var statusList = await _context.StatusLists.FindAsync(id);
            if (statusList == null)
            {
                return NotFound();
            }

            _context.StatusLists.Remove(statusList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusListExists(int id)
        {
            return _context.StatusLists.Any(e => e.Id == id);
        }
    }
}
