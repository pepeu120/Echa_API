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
    public class StatusTransactionController : ControllerBase
    {
        private readonly EchaContext _context;

        public StatusTransactionController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/StatusTransaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusTransaction>>> GetStatusTransactions()
        {
            return await _context.StatusTransactions.ToListAsync();
        }

        // GET: api/StatusTransaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusTransaction>> GetStatusTransaction(int id)
        {
            var statusTransaction = await _context.StatusTransactions.FindAsync(id);

            if (statusTransaction == null)
            {
                return NotFound();
            }

            return statusTransaction;
        }

        // PUT: api/StatusTransaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusTransaction(int id, StatusTransaction statusTransaction)
        {
            if (id != statusTransaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(statusTransaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusTransactionExists(id))
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

        // POST: api/StatusTransaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusTransaction>> PostStatusTransaction(StatusTransaction statusTransaction)
        {
            _context.StatusTransactions.Add(statusTransaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusTransaction", new { id = statusTransaction.Id }, statusTransaction);
        }

        // DELETE: api/StatusTransaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusTransaction(int id)
        {
            var statusTransaction = await _context.StatusTransactions.FindAsync(id);
            if (statusTransaction == null)
            {
                return NotFound();
            }

            _context.StatusTransactions.Remove(statusTransaction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusTransactionExists(int id)
        {
            return _context.StatusTransactions.Any(e => e.Id == id);
        }
    }
}
