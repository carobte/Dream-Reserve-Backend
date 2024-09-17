using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.FlightType
{
    public class FlightTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; }
        public string Description { get; set; } 
    }
}