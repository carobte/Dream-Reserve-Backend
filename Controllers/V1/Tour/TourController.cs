using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.Tour
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class TourController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public TourController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetTour()
        {
            var tours = Context.Tours
                .Select(tour => new TourDTO
                {
                    Id = tour.Id,
                    Name = tour.Name,
                    Price = tour.Price,
                    Category = tour.Category,
                    Description = tour.Description
                })
                .ToList();
            if (tours.Count == 0)
            {
                return NotFound();
            }
            return Ok(tours);
        }
    }
}