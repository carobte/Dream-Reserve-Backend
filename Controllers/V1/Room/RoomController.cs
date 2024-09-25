using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dream_Reserve_Back.Data;
using Dream_Reserve_Back.DTO.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dream_Reserve_Back.Controllers.V1.Room
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDbContext Context;
        public RoomController(ApplicationDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <remarks>
        /// With this method, you can get all rooms
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> GetRoom()
        {
            var rooms = await Context.Rooms.Include(room=>room.Hotel)
                .Select(room => new RoomDTO
                {
                    Id = room.Id,
                    Type = room.Type,
                    RoomNumber = room.RoomNumber,
                    Price = room.Price,
                    Status = room.Status,
                    HotelId = room.HotelId,
                    HotelName= room.Hotel.Name,
                    Description = room.Description,
                    PeopleCapacity = room.PeopleCapacity,
                    UrlImages = room.UrlImages
                })
                .ToListAsync();

            if (!rooms.Any())
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        /// <summary>
        /// Get room by ID
        /// </summary>
        /// <remarks>
        /// With this method, you can get room by ID
        /// </remarks>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await Context.Rooms.Include(room=>room.Hotel)
            .Where(room => room.Id == id)
            .Select(room => new RoomDTO
            {
                Id = room.Id,
                Type = room.Type,
                RoomNumber = room.RoomNumber,
                Price = room.Price,
                Status = room.Status,
                HotelId = room.HotelId,
                HotelName=room.Hotel.Name,
                Description = room.Description,
                PeopleCapacity = room.PeopleCapacity,
                UrlImages = room.UrlImages
            })
            .FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        /// <summary>
        /// Edit room by ID
        /// </summary>
        /// <remarks>
        /// With this method, you can edit room by ID
        /// </remarks>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomDTO roomDto)
        {
            if (roomDto == null)
            {
                return BadRequest("Invalid data.");
            }
            var existingRoom = await Context.Rooms.FindAsync(id);

            if (existingRoom == null)
            {
                return NotFound("Room not found.");
            }

            existingRoom.Type = roomDto.Type;
            existingRoom.RoomNumber = roomDto.RoomNumber;
            existingRoom.Price = roomDto.Price;
            existingRoom.Status = roomDto.Status;
            existingRoom.HotelId = roomDto.HotelId;
            existingRoom.Description = roomDto.Description;
            existingRoom.PeopleCapacity = roomDto.PeopleCapacity;
            existingRoom.UrlImages = roomDto.UrlImages;
            Context.Rooms.Update(existingRoom);

            await Context.SaveChangesAsync();

            return Ok(existingRoom);
        }

        /// <summary>
        /// Delete a room
        /// </summary>
        /// <remarks>
        /// With this method, you can delete a room by ID
        /// </remarks>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRoom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = await Context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound($"No se encontró un tour con el ID {id}.");
            }
            Context.Rooms.Remove(room);
            await Context.SaveChangesAsync();
            return Ok(room);
        }

        /// <summary>
        /// Add a room
        /// </summary>
        /// <remarks>
        /// With this method, you can add a new room
        /// </remarks>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostRoom([FromBody] RoomDTO roomDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var room = new Models.Room
            {
                Type = roomDto.Type,
                RoomNumber = roomDto.RoomNumber,
                Price = roomDto.Price,
                Status = roomDto.Status,
                HotelId = roomDto.HotelId,
                Description = roomDto.Description,
                PeopleCapacity = roomDto.PeopleCapacity,
                UrlImages = roomDto.UrlImages
            };
            Context.Rooms.Add(room);
            await Context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
        }
    }
}