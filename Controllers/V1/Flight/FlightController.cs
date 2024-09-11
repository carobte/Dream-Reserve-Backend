using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Flight;
using Dream_Reserve_Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public FlightController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetFlight()
        {
            var flights = await Context.Flights.Select(flight => new FlightDTO
            {
                Id = flight.Id,
                Name = flight.Name,
                Date = flight.Date,
                Duration = flight.Duration,
                Price = flight.Price,
                Seat = flight.Seat,
                Origin = flight.Origin,
                Destiny = flight.Destiny
            }).ToListAsync();
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var flights = await Context.Flights
            .Where( flight => flight.Id == id)
            .Select(flight => new FlightDTO
            {
                Id = flight.Id,
                Name = flight.Name,
                Date = flight.Date,
                Duration = flight.Duration,
                Price = flight.Price,
                Seat = flight.Seat,
                Origin = flight.Origin,
                Destiny = flight.Destiny
            }
            ).FirstOrDefaultAsync();
            if (flights == null)
            {
                return NotFound();
            }
            return Ok(flights);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] FlightDTO flightDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var flight = new Models.Flight
            {
                Name = flightDTO.Name,
                Date = flightDTO.Date,
                Duration = flightDTO.Duration,
                Price = flightDTO.Price,
                Seat = flightDTO.Seat,
                Origin = flightDTO.Origin,
                Destiny = flightDTO.Destiny
            };
            Context.Flights.Add(flight);
            await Context.SaveChangesAsync();
            return Ok(flight);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight([FromRoute] int id, [FromBody] FlightDTO flightDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != flightDTO.Id)
            {
                return BadRequest();
            }
            var flight = new Models.Flight
            {
                Id = flightDTO.Id,
                Name = flightDTO.Name,
                Date = flightDTO.Date,
                Duration = flightDTO.Duration,
                Price = flightDTO.Price,
                Seat = flightDTO.Seat,
                Origin = flightDTO.Origin,
                Destiny = flightDTO.Destiny
            };

            Context.Entry(flight).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(flight);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var flight = await Context.Flights.FindAsync(id);
            if (flight == null)
            {
                return NotFound();
            }
            Context.Flights.Remove(flight);
            await Context.SaveChangesAsync();
            return Ok(flight);
        }

    }
}