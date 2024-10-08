using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Config;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Person;
using Dream_Reserve_Back.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly Utilities Utilities;
        public PeopleController(ApplicationDbContext context, Utilities utilities)
        {
            Context = context;
            Utilities = utilities;
        }

        /// <summary>
        /// Get all people
        /// </summary>
        /// <remarks>
        /// This endpoint returns all the people in the database
        /// </remarks>
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
                UrlAvatar = person.UrlAvatar
            }
            ).ToListAsync();

            if (people == null || people.Count == 0)
            {
                return NotFound();
            }

            return Ok(people);
        }

        /// <summary>
        /// Get one person by Id
        /// </summary>
        /// <remarks>
        /// This endpoint returns the information for one specific person in the database by Id.
        /// </remarks>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson([FromRoute] int id)
        {
            var person = await Context.People
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
                UrlAvatar = person.UrlAvatar

            })
            .FirstOrDefaultAsync();

            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        /// <summary>
        /// Create Person
        /// </summary>
        /// <remarks>
        /// This endpoint creates a person in the database.
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDTO personDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (Context.People.Any(u => u.Email == personDTO.Email))
            {
                return BadRequest("Email already exists");
            }

            var person = new Models.Person
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                LastName = personDTO.LastName,
                DocumentTypeId = personDTO.DocumentTypeId,
                DocumentNumber = personDTO.DocumentNumber,
                Email = personDTO.Email,
                Password = Utilities.EncryptSHA256(personDTO.Password),
                UrlAvatar = personDTO.UrlAvatar

            };

            Context.People.Add(person);
            await Context.SaveChangesAsync();
            return Ok(person);
        }

        /// <summary>
        /// Edit Person by Id
        /// </summary>
        /// <remarks>
        /// This endpoint Edits a person in the database by Id.
        /// </remarks>
        [HttpPut("{id}")]
        [Authorize]
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
                Password = Utilities.EncryptSHA256(personDTO.Password),
                UrlAvatar = personDTO.UrlAvatar

            };

            Context.Entry(person).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Ok(person);
        }
        /// <summary>
        /// Delete Person by Id
        /// </summary>
        /// <remarks>
        /// This endpoint Deletes a person in the database by Id.
        /// </remarks>
        [HttpDelete("{id}")]
        [Authorize]
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