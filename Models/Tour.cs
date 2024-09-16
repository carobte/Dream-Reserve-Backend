using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back.Models;

public partial class Tour
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string Category { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string UrlImages { get; set; } = null!;

    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();
}
