using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string DocumentNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int DocumentTypeId { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;
    public string UrlAvatar {get;set;} = null!; 


    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
