using Encore.Domain.Interfaces.CrossCutting;
using Encore.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Encore.Infra.CrossCutting.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var secretKey = _configuration["JwtApp:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
                throw new InvalidOperationException("JWT secret key is missing or invalid.");

            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Issuer = _configuration["JwtApp:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["JwtApp:ExpirationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
