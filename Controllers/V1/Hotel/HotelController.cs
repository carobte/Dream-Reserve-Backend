using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Hotel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.Hotel
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public HotelController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await Context.Hotels
            .Select(hotel => new HotelDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Nit = hotel.Nit,
                Address = hotel.Address,
                Phone = hotel.Phone,
                Email = hotel.Email,
                Description = hotel.Description,
            }
            ).ToListAsync();

            if (hotels == null)
            {
                return NotFound();
            }
            return Ok(hotels);
        }
    }
}