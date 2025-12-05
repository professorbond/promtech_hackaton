using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Entities;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginData)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == loginData.Username && u.Password == loginData.Password);

            if (user == null)
            {
                return Unauthorized(new { message = "Неверный логин или пароль" });
            }
            else
            {
                return Ok(new { user.Username, user.Role });
            }
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            if (await _context.Users.AnyAsync(u => u.Username == newUser.Username))
                return BadRequest(new { message = "Пользователь с таким именем уже существует" });

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok(new { newUser.Username, newUser.Role });
        }
    }
}
