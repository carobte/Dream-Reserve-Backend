using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back.Models;

public partial class DocumentType
{
    public int Id { get; set; }

    public string Abbreviation { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
