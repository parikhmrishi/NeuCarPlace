using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeuCarPlace.Domain.Contexts;
using NeuCarPlace.Domain.Entities;

namespace NeuCarPlace.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly NeuCarPlaceDbContext _context;

        public UsersController(NeuCarPlaceDbContext context)
        {
            _context = context;
        }

        // GET: api/Users/5
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUser([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.Password);
        }


        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!UserExists(user.Email))
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { email = user.Email }, user);
            }
            else return (BadRequest("User Exists"));
        }


        private bool UserExists(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }
    }
}