using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Person;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.People
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public PeopleController(ApplicationDbContext context)
        {
            Context = context;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            var people = Context.People
            .Include(person => person.DocumentType)
            .Select(person => new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                DocumentTypeName = person.DocumentType.Name,
                DocumentNumber = person.DocumentNumber,
                Email = person.Email,
                Password = person.Password
            }
            ).ToList();

            if (people == null || people.Count == 0)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await Context.People
            .Include(person => person.DocumentType)
            .Where(person => person.Id == id)
            .Select(person => new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                DocumentTypeName = person.DocumentType.Name,
                DocumentNumber = person.DocumentNumber,
                Email = person.Email,
                Password = person.Password
            })
            .FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

    }
}
