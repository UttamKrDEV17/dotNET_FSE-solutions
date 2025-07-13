using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiJwtDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        [HttpGet("generate-token")]
        public IActionResult GenerateToken(int userId = 1, string userRole = "Admin")
        {
            var token = GenerateJSONWebToken(userId, userRole);
            return Ok(new { Token = token });
        }

        private string GenerateJSONWebToken(int userId, string userRole)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsAVeryLongSecretKeyForJWTTokenGeneration123456789"));
    
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    
            
            
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };
            
            var token = new JwtSecurityToken(
                issuer: "mySystem",
                audience: "myUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(10), // Token expires in 10 minutes
                signingCredentials: credentials);
                
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
