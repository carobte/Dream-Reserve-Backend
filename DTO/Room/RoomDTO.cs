using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Room
{
    public class RoomDTO
    {
        public int Id { get; set; }

        public string Type { get; set; } = null!;

        public int RoomNumber { get; set; }

        public decimal Price { get; set; }

        public string Status { get; set; } = null!;

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public string Description { get; set; } = null!;

        public int PeopleCapacity { get; set; }

        public string UrlImages { get; set; } = null!;


    }
}