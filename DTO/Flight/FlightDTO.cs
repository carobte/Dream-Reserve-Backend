using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Flight
{
    public class FlightDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime Date { get; set; }
        public string? Duration { get; set; }
        public string? Seat { get; set; }
        public string? Origin { get; set; }
        public string? Destiny { get; set; }

    }
}