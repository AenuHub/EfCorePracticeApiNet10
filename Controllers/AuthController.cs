using EfCorePracticeApiNet10.Data;
using EfCorePracticeApiNet10.DTOs;
using EfCorePracticeApiNet10.Models;
using EfCorePracticeApiNet10.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCorePracticeApiNet10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly PasswordService _passwordService;
        private readonly JwtService _jwtService;

        public AuthController(AppDbContext context, PasswordService passwordService, JwtService jwtService)
        {
            _context = context;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(x => x.Username == dto.Username))
            {
                return BadRequest("Username is taken");
            }

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = _passwordService.HashPassword(dto.Password),
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("Register is successful");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == dto.Username);
            if (user == null) return Unauthorized("User not found");

            if (!_passwordService.Verify(user.PasswordHash, dto.Password))
            {
                return Unauthorized("Wrong password");
            }

            var token = _jwtService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}
