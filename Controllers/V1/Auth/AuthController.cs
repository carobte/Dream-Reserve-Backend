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
        public async Task<IActionResult> Login(LoginRequest request){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.People.FirstOrDefaultAsync(person => person.Email == request.Email);
            if (user == null)
            {
                return Unauthorized("Invalid email"); //cambiar mensaje del error
            }

            var passwordValid = user.Password == _utilities.EncryptSHA256(request.Password);

            if (passwordValid == false)
            {
                return Unauthorized("Invalid password"); //cambiar mensaje del error
            }

            return Ok("login");
        }
    }
}