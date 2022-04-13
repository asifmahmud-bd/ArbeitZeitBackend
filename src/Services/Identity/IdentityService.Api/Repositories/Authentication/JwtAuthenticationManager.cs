using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityService.Api.Entities;
using IdentityService.Application.Domain;
using Microsoft.IdentityModel.Tokens;

namespace IdentityService.Api.Repositories.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _tokenKey; 

        public JwtAuthenticationManager(string secretKey)
        {
            _tokenKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
        }

        public string Authenticate(LoginCredential credential, User user)
        {
            if (user.LoginId != credential.Username && user.Password != credential.Password)
            {
                return null;
            }

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credential.Username)
                }),

                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                                                           SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenhandler.CreateToken(tokenDescriptor);

            return tokenhandler.WriteToken(token);

        }
    }
}
