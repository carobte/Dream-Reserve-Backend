using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Tour;
public class TourDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Category { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string UrlImages { get; set; } = null!;
}
