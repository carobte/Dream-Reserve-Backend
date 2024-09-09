using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back;

public partial class Room
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int RoomNumber { get; set; }

    public decimal Price { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();
}
