using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dream_Reserve_Back.DTO.Person
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? DocumentNumber { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? UrlAvatar {get;set;}
        public int DocumentTypeId { get; set; }
        public string? DocumentTypeName { get; set; }

    }
}