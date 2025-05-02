using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.DTOs;
using server.Repository;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly RepositoryContext _context;

        public UserController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            return user;
        }

        // GET: api/User/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound("Пользователь с таким email не найден");
            }

            return user;
        }

        // POST: api/User/register
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegistrationDto registrationDto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == registrationDto.Email))
            {
                return BadRequest("Пользователь с таким email уже существует");
            }

            var user = new User
            {
                FirstName = registrationDto.FirstName,
                LastName = registrationDto.LastName,
                MiddleName = registrationDto.MiddleName,
                Position = registrationDto.Position,
                Organization = registrationDto.Organization,
                Address = registrationDto.Address,
                PhoneNumber = registrationDto.PhoneNumber,
                Email = registrationDto.Email,
                PasswordHash = HashPassword(registrationDto.Password),
                Role = registrationDto.Role,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // POST: api/User/login
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserLoginDto loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || user.PasswordHash != HashPassword(loginDto.Password))
            {
                return Unauthorized("Неверный email или пароль");
            }

            return user;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDto updateDto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            // Проверяем, не пытается ли пользователь изменить email на уже существующий
            if (updateDto.Email != user.Email && 
                await _context.Users.AnyAsync(u => u.Email == updateDto.Email))
            {
                return BadRequest("Пользователь с таким email уже существует");
            }

            // Обновляем данные пользователя
            user.FirstName = updateDto.FirstName;
            user.LastName = updateDto.LastName;
            user.MiddleName = updateDto.MiddleName;
            user.Position = updateDto.Position;
            user.Organization = updateDto.Organization;
            user.Address = updateDto.Address;
            user.PhoneNumber = updateDto.PhoneNumber;
            user.Email = updateDto.Email;
            user.Role = updateDto.Role;

            // Если предоставлен новый пароль, обновляем его
            if (!string.IsNullOrEmpty(updateDto.NewPassword))
            {
                user.PasswordHash = HashPassword(updateDto.NewPassword);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound("Пользователь не найден");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Пользователь не найден");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
} 