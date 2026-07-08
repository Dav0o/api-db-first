using api_db_first.Interfaces;
using api_db_first.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_db_first.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config) => _config = config;

        public string GenerateToken(User user, IList<string> roles)
        {
            var settings = _config.GetSection("JwtSettings");
            var secretKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(settings["SecretKey"]!));

            var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Email, user.Email),
        };

            // Agrega un claim por cada rol del usuario
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

            var token = new JwtSecurityToken(
                issuer: settings["Issuer"],
                audience: settings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                                        int.Parse(settings["ExpirationMinutes"]!)),
                signingCredentials: new SigningCredentials(
                                        secretKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
