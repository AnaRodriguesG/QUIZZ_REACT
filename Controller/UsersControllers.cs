using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly QuizContext _context;

    public UsersController(QuizContext context)
    {
        _context = context;
    }

    // POST: api/Users/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user, string password)
    {
        if (await _context.Usuarios.AnyAsync(u => u.Email == user.Email))
            return BadRequest("Email already exists");

        user.SenhaHash = PasswordHasher.HashPassword(password); // Gerar o hash da senha
        _context.Usuarios.Add(user);
        await _context.SaveChangesAsync();

        return Ok("User registered successfully");
    }

    // POST: api/Users/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
            return NotFound("User not found");

        if (!PasswordHasher.VerifyPassword(password, user.SenhaHash))
            return Unauthorized("Invalid password");

        return Ok("Login successful");
    }
}
