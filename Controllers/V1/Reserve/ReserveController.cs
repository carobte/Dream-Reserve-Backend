using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Reserve;
using Dream_Reserve_Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.Reserves
{
    [ApiController]
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
                .Select(reserve => new ReserveDTO
                {
                    Id = reserve.Id,
                    PersonId = reserve.PersonId,
                    RoomId = reserve.RoomId,
                    FoodId = reserve.FoodId,
                    FlightId = reserve.FlightId,
                    TourId = reserve.TourId,
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
              .Select(reserve => new ReserveDTO
              {
                  Id = reserve.Id,
                  PersonId = reserve.PersonId,
                  RoomId = reserve.RoomId,
                  FoodId = reserve.FoodId,
                  FlightId = reserve.FlightId,
                  TourId = reserve.TourId,
                  CheckIn = reserve.CheckIn,
                  CheckOut = reserve.CheckOut,
                  PeopleCuantity = reserve.PeopleCuantity,
                  Total = reserve.Total
              }).ToListAsync();

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
                .Select(reserve => new ReserveDTO
                {
                    Id = reserve.Id,
                    PersonId = reserve.PersonId,
                    RoomId = reserve.RoomId,
                    FoodId = reserve.FoodId,
                    FlightId = reserve.FlightId,
                    TourId = reserve.TourId,
                    CheckIn = reserve.CheckIn,
                    CheckOut = reserve.CheckOut,
                    PeopleCuantity = reserve.PeopleCuantity,
                    Total = reserve.Total
                })
                .FirstOrDefaultAsync();

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
