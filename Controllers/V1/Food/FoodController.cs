using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Food;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.Food
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public FoodController(ApplicationDbContext context){
            Context = context;
        }

        //metodo GET
        /// <summary>
        /// Get in general
        /// </summary>
        /// <remarks>
        /// this endpoint returns in general the food in the db
        /// </remarks>
        [HttpGet] 
        public async Task<IActionResult> GetFoods(){
            var foods = await Context.Foods.Select(food => new FoodDTO{
                Id = food.Id,
                Cuantity = food.Cuantity,
                Price = food.Price,
                Description = food.Description
            }).ToListAsync();
            if (foods == null || foods.Count == 0 )
            {
                return NotFound();      
            }
            return Ok(foods);
        }

         /// <summary>
        /// Get for Id
        /// </summary>
        /// <remarks>
        /// this endpoint returns the search of food by id.
        /// </remarks>
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetFood([FromRoute]int id)
        {
            var food = await Context.Foods
            .Where( food => food.Id == id)
            .Select(food => new FoodDTO
            {
                Id = food.Id,
                Cuantity = food.Cuantity,
                Price = food.Price,
                Description = food.Description
            }
            ).FirstOrDefaultAsync(food => food.Id == id);

            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        //metodo delete
        /// <summary>
        /// delete a food
        /// </summary>
        /// <remarks>
        /// This endpoint delete food in the database 
        /// </remarks>



        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFood([FromRoute] int id){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var food = await Context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }

            Context.Foods.Remove(food);
            await Context.SaveChangesAsync();
            return Ok(food);
        }

        //metodo POST
        /// <summary>
        /// Create a food
        /// </summary>
        /// <remarks>
        /// This endpoint create food in the database 
        /// </remarks>

        [HttpPost]
        [Authorize]
        public async  Task<IActionResult> PostFood ([FromBody] FoodDTO foodDTO){
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var food = new Models.Food{
                Cuantity = foodDTO.Cuantity,
                Price = foodDTO.Price,
                Description = foodDTO.Description
            };
            Context.Foods.Add(food);
            await Context.SaveChangesAsync();
            return Ok(food);
        }

        //metodo PUT
        /// <summary>
        /// edit a food
        /// </summary>
        /// <remarks>
        /// This endpoint edit food in the database by id
        /// </remarks>

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutFood([FromRoute] int id, [FromBody] FoodDTO foodDTO){
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != foodDTO.Id)
            {
                return BadRequest();
            }
            var food = new Models.Food
            {
                Id = foodDTO.Id,
                Cuantity = foodDTO.Cuantity,
                Price = foodDTO.Price,
                Description = foodDTO.Description
            };
            Context.Entry(food).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(food);
        }

    }
}