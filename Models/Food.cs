using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back;

public partial class Food
{
    public int Id { get; set; }

    public int Cuantity { get; set; }

    public decimal Price { get; set; }

    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();
}
