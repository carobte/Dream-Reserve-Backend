using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Food;
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
        [HttpGet] //get general
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
        [HttpGet("{id}")] //get for id
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


        [HttpDelete("{id}")]
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

        [HttpPost]
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

        [HttpPut("{id}")]
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