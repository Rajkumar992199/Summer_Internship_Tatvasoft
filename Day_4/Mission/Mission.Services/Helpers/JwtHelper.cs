using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mission.Entities.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mission.Services.Helpers
{
    public class JwtHelper(IConfiguration config)
    {
        private IConfiguration _config = config;

        public string GetJwtToken(User users)
        {
            // Ensure the configuration value is not null or empty
            string jwtKey = _config["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key configuration is missing or null.");
            SymmetricSecurityKey? securityKey = new(Encoding.UTF8.GetBytes(jwtKey));
            SigningCredentials? creds = new(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[]? claims =
            [
               new Claim("userId",users.Id.ToString()),
                    new Claim("fullName",users.FirstName+" "+users.LastName),
                    new Claim("firstName",users.FirstName),
                    new Claim("lastName",users.LastName),
                    new Claim("emailAddress",users.EmailAddress),
                    new Claim(ClaimTypes.Role, users.UserType.ToLower()),
                    new Claim("userImage",users.UserImage)
            ];

            JwtSecurityToken? token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
