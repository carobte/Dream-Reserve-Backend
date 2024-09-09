using System;
using System.Collections.Generic;

namespace Dream_Reserve_Back;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? DocumentNumber { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int DocumentTypeId { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<Reserve> Reserves { get; set; } = new List<Reserve>();
}
