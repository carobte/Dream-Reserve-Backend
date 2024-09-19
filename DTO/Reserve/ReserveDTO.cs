using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Reserve
{
    public class ReserveDTO
    {
        public int Id { get; set; }
        
        public int PersonId { get; set; }
        
        public int? RoomId { get; set; }
        
        public int? FoodId { get; set; }
        
        public int? FlightId { get; set; }
        
        public int? TourId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int PeopleCuantity { get; set; }

        public decimal Total { get; set; }
    }
}