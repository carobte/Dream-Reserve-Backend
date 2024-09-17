using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back.Models;

public partial class Food
{
    public int Id { get; set; }

    public string Cuantity { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();
}
