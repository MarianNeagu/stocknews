using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StockNews.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockNews.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configurationTokenService;
        private readonly UserManager<User> userManager;

        public TokenService(IConfiguration configuration, UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.configurationTokenService = configuration;
        }

        public async Task<string> CreateToken(User user)
        {
            var secretKey = configurationTokenService.GetSection("Jwt").GetSection("SecretKey").Get<string>();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            //algorithms for cryptography that use the same cryptographic keys for both the encryption of plaintext
            //and the decryption of ciphertext
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>();
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var username = await userManager.GetUserNameAsync(user);
            claims.Add(new Claim("username", username));
            var userId = await userManager.GetUserIdAsync(user);
            claims.Add(new Claim("userId", userId));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
