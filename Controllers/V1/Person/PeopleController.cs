using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Person;
using Dream_Reserve_Back.Models;
using Microsoft.AspNetCore.Identity;
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
        public async Task<IActionResult> GetPeople()
        {
            var people = await Context.People
            .Include(person => person.DocumentType)
            .Select(person => new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                DocumentTypeId = person.DocumentType.Id,
                DocumentTypeName = person.DocumentType.Name,
                DocumentNumber = person.DocumentNumber,
                Email = person.Email,
                Password = person.Password
            }
            ).ToListAsync();

            if (people == null || people.Count == 0)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            var person = await Context.People
            .Include(person => person.DocumentType)
            .Where(person => person.Id == id)
            .Select(person => new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                LastName = person.LastName,
                DocumentTypeId = person.DocumentTypeId,
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

        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var person = new Models.Person
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                LastName = personDTO.LastName,
                DocumentTypeId = personDTO.DocumentTypeId,
                DocumentNumber = personDTO.DocumentNumber,
                Email = personDTO.Email,
                Password = personDTO.Password
            };

            var passwordHasher = new PasswordHasher<Person>();

            // Hash the password and assign it to the user's Password property
            person.Password = passwordHasher.HashPassword(person, personDTO.Password);

            Context.People.Add(person);
            await Context.SaveChangesAsync();
            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson([FromRoute] int id, [FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personDTO.Id)
            {
                return BadRequest();
            }

            var person = new Models.Person
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                LastName = personDTO.LastName,
                DocumentTypeId = personDTO.DocumentTypeId,
                DocumentNumber = personDTO.DocumentNumber,
                Email = personDTO.Email,
                Password = personDTO.Password
            };

            Context.Entry(person).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var person = await Context.People.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            Context.People.Remove(person);
            await Context.SaveChangesAsync();
            return Ok(person);
        }

    }
}
