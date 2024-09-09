using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back;

public partial class Flight
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();
}
