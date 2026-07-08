using api_db_first.Data;
using api_db_first.DTOs;
using api_db_first.Interfaces;
using api_db_first.Models;
using Microsoft.EntityFrameworkCore;

namespace api_db_first.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly IJwtService _jwtService;

        public AuthService(AppDbContext db, IJwtService jwtService)
        {
            _db = db;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            
            var user = await _db.Users
                .Include(u => u.Roles)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            var roles = user.Roles.Select(r => r.Name).ToList();
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Roles = roles
            };
        }

        public async Task<AuthResponseDto?> RegisterAsync(RegisterRequestDto dto)
        {
            // Verifica si el email ya está registrado
            var exists = await _db.Users.AnyAsync(u => u.Email == dto.Email);
            if (exists) return null;

            // Busca el rol "User" en la BD
            var defaultRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "User");
            if (defaultRole is null) return null;

            // Crea el usuario con la contraseña hasheada
            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            // Asigna el rol por defecto
            user.Roles.Add(defaultRole);

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            // Retorna el token igual que en el login
            var roles = user.Roles.Select(r => r.Name).ToList();
            var token = _jwtService.GenerateToken(user, roles);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Roles = roles
            };
        }
    }
}
