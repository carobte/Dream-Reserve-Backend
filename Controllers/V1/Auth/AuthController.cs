using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Person;
using Dream_Reserve_Back.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dream_Reserve_Back.DTO.Login;

namespace Dream_Reserve_Back.Controllers.V1.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;
        private readonly IConfiguration Configuration;
        private readonly PasswordHasher<Person> PasswordHasher;

        // Constructor
        public AuthController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            DbContext = dbContext;
            Configuration = configuration;
            PasswordHasher = new PasswordHasher<Person>();
        }

        // Generate JWT token for authenticated users
        private string GenerateJwtToken(string email)
        {
            // Create a security key using the secret key from configuration.
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT_KEY"]));

            // Create signing credentials using the security key and HMAC-SHA256 algorithm.
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define the claims to include in the token, such as the user's email and a unique identifier (JTI).
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Build the JWT token with the defined issuer, audience, claims, expiration time, and signing credentials.
            var token = new JwtSecurityToken(
                issuer: Configuration["JWT_ISSUER"],
                audience: Configuration["JWT_AUDIENCE"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(Configuration["JWT_EXPIREMINUTES"])),
                signingCredentials: credentials                    // Signing credentials for token security
            );

            // Return the JWT token as a string.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // User Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO personLogin)
        {
            // Check if the request body or essential fields (Email and Password) are null or empty.
            if (personLogin == null || string.IsNullOrEmpty(personLogin.Email) || string.IsNullOrEmpty(personLogin.Password))
            {
                return BadRequest(new { Message = "Fields are empty." });
            }

            // Look for a user in the database with the provided email.
            var user = await DbContext.People.FirstOrDefaultAsync(u => u.Email == personLogin.Email);
            if (user == null)
            {
                return BadRequest(new { Message = "Invalid email or password" });
            }

            // Verify the password using the password hasher.
            var passwordVerificationResult = PasswordHasher.VerifyHashedPassword(user, user.Password, personLogin.Password);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return BadRequest(new { Message = "Incorrect password" });
            }

            // Generate a JWT for the authenticated user
            var token = GenerateJwtToken(user.Email);
            return Ok(new
            {
                message = "Success",
                data = new
                {
                    id = user.Id,
                    email = user.Email,
                    token
                }
            });
        }
    }
}
