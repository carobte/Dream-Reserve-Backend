using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back.Models;

public partial class Reserve
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

    public virtual Flight Flight { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual Tour Tour { get; set; } = null!;
}
