using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;

namespace echa_backend_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationMethodController : ControllerBase
    {
        private readonly EchaContext _context;

        public AuthenticationMethodController(EchaContext context)
        {
            _context = context;
        }

        // GET: api/AuthenticationMethod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthenticationMethod>>> GetAuthenticationMethods()
        {
            return await _context.AuthenticationMethods.ToListAsync();
        }

        // GET: api/AuthenticationMethod/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthenticationMethod>> GetAuthenticationMethod(int id)
        {
            var authenticationMethod = await _context.AuthenticationMethods.FindAsync(id);

            if (authenticationMethod == null)
            {
                return NotFound();
            }

            return authenticationMethod;
        }

        // PUT: api/AuthenticationMethod/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthenticationMethod(int id, AuthenticationMethod authenticationMethod)
        {
            if (id != authenticationMethod.Id)
            {
                return BadRequest();
            }

            var existingAuthenticationMethod = await _context.AuthenticationMethods
                .AsNoTracking()
                .FirstOrDefaultAsync(am => am.Id == id);

            if (existingAuthenticationMethod == null)
            {
                return NotFound();
            }

            authenticationMethod.CreationDate = existingAuthenticationMethod.CreationDate;

            _context.Entry(authenticationMethod).State = EntityState.Modified;
            _context.Entry(authenticationMethod).Property(am => am.CreationDate).IsModified = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthenticationMethodExists(id))
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

        // POST: api/AuthenticationMethod
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthenticationMethod>> PostAuthenticationMethod(AuthenticationMethod authenticationMethod)
        {
            _context.AuthenticationMethods.Add(authenticationMethod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthenticationMethod", new { id = authenticationMethod.Id }, authenticationMethod);
        }

        // DELETE: api/AuthenticationMethod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthenticationMethod(int id)
        {
            var authenticationMethod = await _context.AuthenticationMethods.FindAsync(id);
            if (authenticationMethod == null)
            {
                return NotFound();
            }

            _context.AuthenticationMethods.Remove(authenticationMethod);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthenticationMethodExists(int id)
        {
            return _context.AuthenticationMethods.Any(e => e.Id == id);
        }
    }
}
