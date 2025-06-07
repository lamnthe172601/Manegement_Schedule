using Management_Schedule_BE.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Management_Schedule_BE.Services.SystemSerivce
{
    public class JWTConfig
    {
        private readonly IConfiguration _configuration;

        public JWTConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(UserDTO user)
        {
            string role = takeARole(user.Role);
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            //lay chu ky
            var serectKeyBytes = Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]);
            //data o description
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]{
                   new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()), // userID
            new Claim(ClaimTypes.Name, user.Email),                      // Email
            new Claim(JwtRegisteredClaimNames.Email, user.Email),        // Email (JWT standard claim)
            new Claim("fullName", user.FullName ?? ""),                   // fullName
            new Claim("gender", user.Gender ?? ""),                       // gender
            new Claim("phone", user.Phone ?? ""),
            new Claim("address", user.Address ?? ""),
           new Claim("dateOfBirth", user.DateOfBirth.HasValue ? user.DateOfBirth.Value.ToString("yyyy-MM-dd") : ""),
            new Claim("role", role)       
                    
                    //roles
                }),
                Expires = DateTime.UtcNow.AddMonths(3),
                Audience = _configuration["JWT:ValidAudience"],
                Issuer = _configuration["JWT:ValidIssuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (serectKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            //create token
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            var accessToken = jwtTokenHandler.WriteToken(token);
            return accessToken;
        }

        private static string takeARole(byte role)
        {
            // 1=Admin, 2=Teacher, 3=Student
            if (role == 1) return "Admin";
            if (role == 2) return "Teacher";
            if (role == 3) return "Student";
            return "";
        }
    }
}
