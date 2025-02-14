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
            var lists = await _context.Lists
                .Select(l =>
                    new List
                    {
                        Id = l.Id,
                        UserId = l.UserId,
                        FontId = l.FontId,                        
                        StatusListId = l.StatusListId,
                        Title = l.Title,
                        Description = l.Description,
                        HighlightColor = l.HighlightColor,
                        Image = l.Image,
                        TotalValue = l.Items.Sum(i => i.TotalValue),
                        ValueCollected = l.Items.SelectMany(i => i.Contributions).Sum(c => c.Value),
                        EventDate = l.EventDate,
                        CreationDate = l.CreationDate,
                        UpdateDate = l.UpdateDate,
                    })
                .ToListAsync();

            return lists;
        }

        // GET: api/List/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List>> GetList(Guid id)
        {
            var list = await _context.Lists
                .Include(l => l.Font)
                .Include(l => l.Items)
                    .ThenInclude(i => i.Contributions)
                .Include(l => l.StatusList)
                .Include(l => l.User)
                .SingleOrDefaultAsync(l => l.Id == id);

            if (list == null)
            {
                return NotFound();
            }

            list.TotalValue = list.Items?.Sum(i => i.TotalValue) ?? 0;
            list.ValueCollected = list.Items?.SelectMany(i => i.Contributions).Sum(c => c.Value) ?? 0;

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
        
        // POST: api/List/5/cashout
        [HttpPost("{id}/cashout")]
        public async Task<IActionResult> CashOut(Guid id)
        {
            var list = await _context.Lists
                .Include(l => l.User)
                .SingleOrDefaultAsync(l => l.Id == id);

            if (list == null)
            {
                return NotFound("Lista não encontrada.");
            }

            var user = list.User;

            if (string.IsNullOrWhiteSpace(user!.PixKey))
            {
                return BadRequest("Você precisa cadastrar uma PixKey antes de solicitar o saque.");
            }

            // Altera o StatusListId para 2
            list.StatusListId = 2;

            _context.Entry(list).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Saque solicitado com sucesso.");
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
