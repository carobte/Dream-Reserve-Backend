using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Hotel
{
    public class HotelDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Nit { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
    }
}