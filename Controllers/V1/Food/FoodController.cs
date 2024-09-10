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
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public FoodController(ApplicationDbContext context){
            Context = context;
        }
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
    }
}