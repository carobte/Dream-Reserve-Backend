using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Reserve;
using Dream_Reserve_Back.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.Reserves
{
    [ApiController]
    [Authorize] //Esto hace que el endpoint o en este caso los endpoints necesiten autorizacion 
    [Route("api/V1/[controller]")]
    public class ReservesController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public ReservesController(ApplicationDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Get all reserves
        /// </summary>
        /// <remarks>
        /// This endpoint returns all the reserves in the database.
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetReserves()
        {
            var reserves = await Context.Reserves

                .Include(reserve => reserve.Person)
                .Include(reserve => reserve.Room)
                .Include(reserve => reserve.Food)
                .Include(reserve => reserve.Flight)
                .Include(reserve => reserve.Tour)

                .Select(reserve => new ReserveGetDTO
                {
                    Id = reserve.Id,
                    PersonId = reserve.PersonId,
                    PersonName = reserve.Person.Name,
                    PersonLastName = reserve.Person.LastName,

                    RoomName = reserve.Room != null ? reserve.Room.RoomNumber : 0,
                    RoomType = reserve.Room != null ? reserve.Room.Type : string.Empty,
                    RoomPrice = reserve.Room != null ? reserve.Room.Price : 0,
                    HotelName = reserve.Room != null && reserve.Room.Hotel != null ? reserve.Room.Hotel.Name : string.Empty,
                    FoodDescription = reserve.Food != null ? reserve.Food.Description : string.Empty,
                    FoodPrice = reserve.Food != null ? reserve.Food.Price : 0,
                    FlightName = reserve.Flight != null ? reserve.Flight.Name : string.Empty,
                    FlightDuration = reserve.Flight != null ? reserve.Flight.Duration : string.Empty,
                    FlightPrice = reserve.Flight != null ? reserve.Flight.Price : 0,
                    TourName = reserve.Tour != null ? reserve.Tour.Name : string.Empty,
                    TourPrice = reserve.Tour != null ? reserve.Tour.Price : 0,

                    CheckIn = reserve.CheckIn,
                    CheckOut = reserve.CheckOut,
                    PeopleCuantity = reserve.PeopleCuantity,
                    Total = reserve.Total
                })
                .ToListAsync();

            if (reserves == null || reserves.Count == 0)
            {
                return NotFound();
            }

            return Ok(reserves);
        }

        /// <summary>
        /// Get all reserves for an specific person
        /// </summary>
        /// <remarks>
        /// This endpoint returns all the reserves in the database for an specific person by the id.
        /// </remarks>

        [HttpGet("/person/{idPerson}")]
        public async Task<IActionResult> GetReservesPerson(int idPerson)
        {
            var person = await Context.People.FindAsync(idPerson);

            var reserves = await Context.Reserves.Where(r => r.PersonId == idPerson)

                .Include(reserve => reserve.Person)
                .Include(reserve => reserve.Room)
                .Include(reserve => reserve.Food)
                .Include(reserve => reserve.Flight)
                .Include(reserve => reserve.Tour)

                .Select(reserve => new ReserveGetDTO
                {
                    Id = reserve.Id,
                    PersonId = reserve.PersonId,
                    PersonName = reserve.Person.Name,
                    PersonLastName = reserve.Person.LastName,

                    RoomName = reserve.Room != null ? reserve.Room.RoomNumber : 0,
                    RoomType = reserve.Room != null ? reserve.Room.Type : string.Empty,
                    RoomPrice = reserve.Room != null ? reserve.Room.Price : 0,
                    HotelName = reserve.Room != null && reserve.Room.Hotel != null ? reserve.Room.Hotel.Name : string.Empty,
                    FoodDescription = reserve.Food != null ? reserve.Food.Description : string.Empty,
                    FoodPrice = reserve.Food != null ? reserve.Food.Price : 0,
                    FlightName = reserve.Flight != null ? reserve.Flight.Name : string.Empty,
                    FlightDuration = reserve.Flight != null ? reserve.Flight.Duration : string.Empty,
                    FlightPrice = reserve.Flight != null ? reserve.Flight.Price : 0,
                    TourName = reserve.Tour != null ? reserve.Tour.Name : string.Empty,
                    TourPrice = reserve.Tour != null ? reserve.Tour.Price : 0,

                    CheckIn = reserve.CheckIn,
                    CheckOut = reserve.CheckOut,
                    PeopleCuantity = reserve.PeopleCuantity,
                    Total = reserve.Total
                })
                .ToListAsync();

            if (reserves == null)
            {
                return NotFound();
            }

            return Ok(reserves);
        }

        /// <summary>
        /// Get one reserve by Id
        /// </summary>
        /// <remarks>
        /// This endpoint returns the information for one specific reserve in the database by Id.
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReserve([FromRoute] int id)
        {
            var reserve = await Context.Reserves
                .Where(reserve => reserve.Id == id)
                .Include(reserve => reserve.Person)
                .Include(reserve => reserve.Room)
                .Include(reserve => reserve.Food)
                .Include(reserve => reserve.Flight)
                .Include(reserve => reserve.Tour)

                .Select(reserve => new ReserveGetDTO
                {
                    Id = reserve.Id,
                    PersonId = reserve.PersonId,
                    PersonName = reserve.Person.Name,
                    PersonLastName = reserve.Person.LastName,

                    RoomName = reserve.Room != null ? reserve.Room.RoomNumber : 0,
                    RoomType = reserve.Room != null ? reserve.Room.Type : string.Empty,
                    RoomPrice = reserve.Room != null ? reserve.Room.Price : 0,
                    HotelName = reserve.Room != null && reserve.Room.Hotel != null ? reserve.Room.Hotel.Name : string.Empty,
                    FoodDescription = reserve.Food != null ? reserve.Food.Description : string.Empty,
                    FoodPrice = reserve.Food != null ? reserve.Food.Price : 0,
                    FlightName = reserve.Flight != null ? reserve.Flight.Name : string.Empty,
                    FlightDuration = reserve.Flight != null ? reserve.Flight.Duration : string.Empty,
                    FlightPrice = reserve.Flight != null ? reserve.Flight.Price : 0,
                    TourName = reserve.Tour != null ? reserve.Tour.Name : string.Empty,
                    TourPrice = reserve.Tour != null ? reserve.Tour.Price : 0,

                    CheckIn = reserve.CheckIn,
                    CheckOut = reserve.CheckOut,
                    PeopleCuantity = reserve.PeopleCuantity,
                    Total = reserve.Total
                })
                .ToListAsync();

            if (reserve == null)
            {
                return NotFound();
            }

            return Ok(reserve);
        }

        /// <summary>
        /// Create reserve
        /// </summary>
        /// <remarks>
        /// This endpoint creates a reserve in the database.
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> CreateReserve([FromBody] ReserveDTO reserveDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reserve = new Models.Reserve
            {
                PersonId = reserveDTO.PersonId,
                RoomId = reserveDTO.RoomId,
                FoodId = reserveDTO.FoodId,
                FlightId = reserveDTO.FlightId,
                TourId = reserveDTO.TourId,
                CheckIn = reserveDTO.CheckIn,
                CheckOut = reserveDTO.CheckOut,
                PeopleCuantity = reserveDTO.PeopleCuantity,
                Total = reserveDTO.Total
            };

            Context.Reserves.Add(reserve);
            await Context.SaveChangesAsync();
            return Ok(reserve);
        }

        /// <summary>
        /// Edit reserve by Id
        /// </summary>
        /// <remarks>
        /// This endpoint edits a reserve in the database by Id.
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReserve([FromRoute] int id, [FromBody] ReserveDTO reserveDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reserveDTO.Id)
            {
                return BadRequest();
            }

            var reserve = new Models.Reserve
            {
                Id = reserveDTO.Id,
                PersonId = reserveDTO.PersonId,
                RoomId = reserveDTO.RoomId,
                FoodId = reserveDTO.FoodId,
                FlightId = reserveDTO.FlightId,
                TourId = reserveDTO.TourId,
                CheckIn = reserveDTO.CheckIn,
                CheckOut = reserveDTO.CheckOut,
                PeopleCuantity = reserveDTO.PeopleCuantity,
                Total = reserveDTO.Total
            };

            Context.Entry(reserve).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(reserve);
        }

        /// <summary>
        /// Delete reserve by Id
        /// </summary>
        /// <remarks>
        /// This endpoint deletes a reserve in the database by Id.
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReserve([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var reserve = await Context.Reserves.FindAsync(id);
            if (reserve == null)
            {
                return NotFound();
            }
            Context.Reserves.Remove(reserve);
            await Context.SaveChangesAsync();
            return Ok(reserve);
        }
    }
}
