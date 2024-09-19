using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Review;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.Review
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public ReviewController(ApplicationDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Get all reviews
        /// </summary>
        /// <remarks>
        /// This endpoint returns all the reviews in the database
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await Context.Reviews
                .Include(r => r.Person)
                .Select(review => new ReviewDTO
                {
                    Id = review.Id,
                    Title = review.Title,
                    Message = review.Message,
                    Rating = review.Rating,
                    CreatedAt = review.CreatedAt,
                    PersonId = review.PersonId,
                    PersonName = review.Person.Name,
                    PersonLastName = review.Person.LastName,
                    PersonUrlAvatar = review.Person.UrlAvatar
                }).ToListAsync();

            return Ok(reviews);
        }

        /// <summary>
        /// Get one review by Id
        /// </summary>
        /// <remarks>
        /// This endpoint returns the information for one specific review in the database by Id.
        /// </remarks>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview([FromRoute] int id)
        {
            var review = await Context.Reviews
            .Where(review => review.Id == id)
            .Select(review => new ReviewDTO
            {
                Id = review.Id,
                Title = review.Title,
                Message = review.Message,
                Rating = review.Rating,
                CreatedAt = review.CreatedAt,
                PersonId = review.PersonId,
                PersonName = review.Person.Name,
                PersonLastName = review.Person.LastName,
                PersonUrlAvatar = review.Person.UrlAvatar

            })
            .FirstOrDefaultAsync();

            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        /// <summary>
        /// Create Review
        /// </summary>
        /// <remarks>
        /// This endpoint creates a review in the database.
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] ReviewDTO reviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = new Models.Review
            {
                Id = reviewDTO.Id,
                Title = reviewDTO.Title,
                Message = reviewDTO.Message,
                Rating = reviewDTO.Rating,
                CreatedAt = DateTime.Now,
                PersonId = reviewDTO.PersonId
            };

            Context.Reviews.Add(review);
            await Context.SaveChangesAsync();
            return Ok(review);
        }

        /// <summary>
        /// Edit a Review by Id
        /// </summary>
        /// <remarks>
        /// This endpoint Edits a review in the database by Id.
        /// </remarks>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview([FromRoute] int id, [FromBody] ReviewDTO reviewDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reviewDTO.Id)
            {
                return BadRequest();
            }

            var review = new Models.Review
            {
                Id = reviewDTO.Id,
                Title = reviewDTO.Title,
                Message = reviewDTO.Message,
                Rating = reviewDTO.Rating,
                CreatedAt = reviewDTO.CreatedAt,
                PersonId = reviewDTO.PersonId
            };

            Context.Entry(review).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(review);
        }

        /// <summary>
        /// Delete a Review by Id
        /// </summary>
        /// <remarks>
        /// This endpoint Deletes a review in the database by Id.
        /// </remarks>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = await Context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            Context.Reviews.Remove(review);
            await Context.SaveChangesAsync();
            return Ok(review);
        }
    }
}