using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Food
{
    public class FoodDTO
    {
        public int Id { get; set; }

        public string? Cuantity { get; set; } 

        public decimal Price { get; set; }

        public string? Description { get; set; } 
    }
}