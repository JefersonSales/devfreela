using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DevFreela.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DevFreela.Infrastructure
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GenerateJwtToken(string email, string role)
        {
            var key = _configuration["Jwt:Key"];
            var Issuer = _configuration["Jwt:Issuer"];
            var Audience = _configuration["Jwt:Audience"];

            var securityKey =  new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim("UserName", email),
                new Claim(ClaimTypes.Role,role)
            };

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                expires: DateTime.Now.AddHours(8),
                signingCredentials:credentials,
                claims:claims
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;

        }
    }
}
