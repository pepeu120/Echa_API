using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly EchaContext _context;

        public ListController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/List
        [HttpGet]
        public async Task<ActionResult<IEnumerable<List>>> GetLists()
        {
            return await _context.Lists.ToListAsync();
        }

        // GET: api/List/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List>> GetList(Guid id)
        {
            var list = await _context.Lists
                .Include(l => l.Font)
                .Include(l => l.Items)
                .Include(l => l.StatusList)
                .Include(l => l.User)
                .SingleOrDefaultAsync(l => l.Id == id);

            if (list == null)
            {
                return NotFound();
            }

            return list;
        }

        // PUT: api/List/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutList(Guid id, List list)
        {
            if (id != list.Id)
            {
                return BadRequest();
            }

            var existingList = await _context.Lists
                .AsNoTracking()
                .FirstOrDefaultAsync(l => l.Id == id);

            if (existingList == null)
            {
                return NotFound();
            }

            list.CreationDate = existingList.CreationDate;

            _context.Entry(list).State = EntityState.Modified;
            _context.Entry(list).Property(l => l.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListExists(id))
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

        // POST: api/List
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List>> PostList(List list)
        {
            _context.Lists.Add(list);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetList", new { id = list.Id }, list);
        }

        // DELETE: api/List/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(Guid id)
        {
            var list = await _context.Lists.FindAsync(id);
            if (list == null)
            {
                return NotFound();
            }

            _context.Lists.Remove(list);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ListExists(Guid id)
        {
            return _context.Lists.Any(e => e.Id == id);
        }
    }
}
