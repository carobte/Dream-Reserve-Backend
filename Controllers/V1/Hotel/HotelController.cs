using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Hotel;
using Microsoft.AspNetCore.Authorization;
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
        

        /// <summary>
        /// Get in general
        /// </summary>
        /// <remarks>
        /// this endpoint returns in general the hotel in the db
        /// </remarks>
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
                UrlImages = hotel.UrlImages,
                City = hotel.City,
                Rating = hotel.Rating
            }
            ).ToListAsync();

            if (hotels == null)
            {
                return NotFound();
            }
            return Ok(hotels);
        }


        /// <summary>
        /// Get for Id
        /// </summary>
        /// <remarks>
        /// this endpoint returns the search of hotel by id.
        /// </remarks>
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
                UrlImages = hotel.UrlImages,
                City = hotel.City,
                Rating = hotel.Rating
            }
            ).FirstOrDefaultAsync(hotel => hotel.Id == id);

            if (hotel == null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        //metodo POST
        /// <summary>
        /// Create a Hotel
        /// </summary>
        /// <remarks>
        /// This endpoint create hotel in the database 
        /// </remarks>
        [HttpPost]	
        [Authorize]
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
                Description = hotelDTO.Description,
                UrlImages = hotelDTO.UrlImages,
                City = hotelDTO.City,
                Rating = hotelDTO.Rating
            };
            Context.Hotels.Add(hotel);
            await Context.SaveChangesAsync();
            return Ok(hotel);
        }

        //metodo PUT
        /// <summary>
        /// edit a Hotel
        /// </summary>
        /// <remarks>
        /// This endpoint edit hotel in the database by id
        /// </remarks>
        [HttpPut("{id}")]
        [Authorize]
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
                Description = hotelDTO.Description,
                UrlImages = hotelDTO.UrlImages,
                City = hotelDTO.City,
                Rating = hotelDTO.Rating
            };

            Context.Entry(hotel).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(hotel);
        }

        //DELETE method
        /// <summary>
        /// delete a Hotel
        /// </summary>
        /// <remarks>
        /// This endpoint delete hotel in the database  by id
        /// </remarks>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteHotel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hotel = await Context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            Context.Hotels.Remove(hotel);
            await Context.SaveChangesAsync();
            return Ok(hotel);
        }
    
    }
}