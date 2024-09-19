using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back.Models;

public partial class Flight
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Duration { get; set; } = null!;

    public string Seat { get; set; } = null!;

    public string Origin { get; set; } = null!;

    public string Destiny { get; set; } = null!;

    public decimal Price { get; set; }
    public int FlightTypeId { get; set; }
    public virtual FlightType FlightType { get; set; } = null!;
    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();
}
