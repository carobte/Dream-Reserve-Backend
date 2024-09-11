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
    [Route("api/V1[controller]")]
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
            var flight = await Context.Flights.Select(flight => new FlightDTO{
                Id = flight.Id,
                Name = flight.Name,
                Date = flight.Date,
                Duration = flight.Duration,
                Price = flight.Price,
                Seat = flight.Seat,
                Origin = flight.Origin,
                Destiny = flight.Destiny
            }).ToListAsync();
            if (flight == null){
                return NotFound();
            }
            return Ok(flight);
       } 

    }
}