using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Tour;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public async Task<IActionResult> GetTour()
        {
            var tours = await Context.Tours
                .Select(tour => new TourDTO
                {
                    Id = tour.Id,
                    Name = tour.Name,
                    Price = tour.Price,
                    Category = tour.Category,
                    Description = tour.Description
                })
                .ToListAsync();
            if (!tours.Any())
            {
                return NotFound();
            }
            return Ok(tours);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTour(int id)
        {
            var tour = await Context.Tours
                .Where(tour => tour.Id == id)
                .Select(tour => new TourDTO
                {
                    Id = tour.Id,
                    Name = tour.Name,
                    Price = tour.Price,
                    Category = tour.Category,
                    Description = tour.Description
                })
                .FirstOrDefaultAsync();

            if (tour == null)
            {
                return NotFound();
            }

            return Ok(tour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTour([FromRoute] int id, [FromBody] TourDTO tourDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != tourDTO.Id)
            {
                return BadRequest("El ID proporcionado en la URL no coincide con el ID en el cuerpo.");
            }
            var tour = await Context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound($"No se encontró un tour con el ID {id}.");
            }
            tour.Name = tourDTO.Name;
            tour.Price = tourDTO.Price;
            tour.Category = tourDTO.Category;
            tour.Description = tourDTO.Description;

            Context.Entry(tour).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourExists(id))
                {
                    return NotFound($"No se encontró un tour con el ID {id} después de la concurrencia.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tour);
        }
        private bool TourExists(int id)
        {
            return Context.Tours.Any(t => t.Id == id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTour([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tour = await Context.Tours.FindAsync(id);
            if (tour == null)
            {
                return NotFound($"No se encontró un tour con el ID {id}.");
            }
            Context.Tours.Remove(tour);
            await Context.SaveChangesAsync();
            return Ok(tour);
        }

        [HttpPost]
        public async Task<IActionResult> PostTour([FromBody] TourDTO tourDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tour = new Models.Tour
            {
                Name = tourDTO.Name,
                Price = tourDTO.Price,
                Category = tourDTO.Category,
                Description = tourDTO.Description
            };
            Context.Tours.Add(tour);
            await Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTour), new { id = tour.Id }, tour);
        }

    }
}