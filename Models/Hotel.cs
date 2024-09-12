using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Nit { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string UrlImages {get;set;} = null!; 
    public string City {get;set;} = null!; 

    public int Rating { get; set; }
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
