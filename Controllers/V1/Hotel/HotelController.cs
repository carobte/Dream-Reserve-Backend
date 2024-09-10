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
        
        //GET general

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
        //metodo GET por id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel([FromRoute]int id)
        {
            var hotel = await Context.Hotels
            .Where( hotel => hotel.Id == id)
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
            ).FirstOrDefaultAsync(hotel => hotel.Id == id);

            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        //metodo POST
        //no usar de momento
        [HttpPost]	
        public async Task<IActionResult> PostHotel([FromBody] HotelDTO hotelDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hotel = new Models.Hotel
            {
                Name = hotelDTO.Name,
                Nit = hotelDTO.Nit,
                Address = hotelDTO.Address,
                Phone = hotelDTO.Phone,
                Email = hotelDTO.Email,
                Description = hotelDTO.Description
            };
            Context.Hotels.Add(hotel);
            await Context.SaveChangesAsync();
            return Ok(hotel);
        }
        //metodo PUT

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel([FromRoute] int id, [FromBody] HotelDTO hotelDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != hotelDTO.Id)
            {
                return BadRequest();
            }
            var hotel = new Models.Hotel
            {
                Id = hotelDTO.Id,
                Name = hotelDTO.Name,
                Nit = hotelDTO.Nit,
                Address = hotelDTO.Address,
                Phone = hotelDTO.Phone,
                Email = hotelDTO.Email,
                Description = hotelDTO.Description
            };

            Context.Entry(hotel).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(hotel);
        }

        
    
    }
}