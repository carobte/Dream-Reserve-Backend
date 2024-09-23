using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Config;
using Dream_Reserve_Back.Data;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.Auth
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly Utilities _utilities;
        public AuthController(ApplicationDbContext context, Utilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.People.FirstOrDefaultAsync(person => person.Email == request.Email);
            var passwordValid = user.Password == _utilities.EncryptSHA256(request.Password);
            
            if (user == null || passwordValid == false)
            {
                return Unauthorized("Invalid email or password"); 
            }

            var token = _utilities.GenerateJwtToken(user);
            return Ok(new
            {
                message = "User logged in successfully, save this token for future http requests",
                jwt = token,
                // Return user info
                userLogged =  new 
                {
                    id = user.Id,
                    name = user.Name,
                    lastName = user.LastName,
                    urlAvatar = user.UrlAvatar,
                    email = user.Email,
                    documentTypeId = user.DocumentTypeId,
                    documentNumber = user.DocumentNumber
                }
            });
        }
    }
}