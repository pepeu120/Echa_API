using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using echa_backend_dotnet.Models;
using echa_backend_dotnet.Services;

namespace echa_backend_dotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly EchaContext _context;
    private readonly TokenService _tokenService;

    public AuthController(EchaContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Auth auth)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == auth.Email);

        if (user == null || !VerifyPassword(auth.Password, user.Password))
            return Unauthorized("Credenciais inválidas");

        var token = _tokenService.GenerateToken(user);
        return Ok(new { token });
    }

    private bool VerifyPassword(string inputPassword, string storedPassword)
    {
        return inputPassword == storedPassword;
    }
}
