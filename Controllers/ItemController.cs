using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly EchaContext _context;

        public ItemController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/Item
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            var items = await _context.Items
                .Select(i => 
                    new Item
                    {
                        Id = i.Id,
                        ListId = i.ListId,
                        CategoryId = i.CategoryId,
                        StatusItemId = i.StatusItemId,
                        Name = i.Name,
                        Description = i.Description,
                        TotalValue = i.TotalValue,
                        ValueCollected = i.Contributions.Sum(c => c.Value),
                        Image = i.Image,
                        CreationDate = i.CreationDate,
                        UpdateDate = i.UpdateDate,
                    })
                .ToListAsync();            

            return items;
        }

        // GET: api/Item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Items
                .Include(i => i.Category)
                .Include(i => i.Contributions)
                .Include(i => i.List)
                .Include(i => i.StatusItem)
                .SingleOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            item.ValueCollected = item.Contributions?.Sum(c => c.Value) ?? 0;
        
            return item;
        }

        // PUT: api/Item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var existingItem = await _context.Items
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingItem == null)
            {
                return NotFound();
            }

            item.CreationDate = existingItem.CreationDate;

            _context.Entry(item).State = EntityState.Modified;
            _context.Entry(item).Property(i => i.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
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

        // POST: api/Item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/Item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
