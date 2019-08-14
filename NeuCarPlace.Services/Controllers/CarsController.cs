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
    public class CarsController : ControllerBase
    {
        private readonly NeuCarPlaceDbContext _context;

        public CarsController(NeuCarPlaceDbContext context)
        {
            _context = context;
        }

        // GET: api/Cars
        [HttpGet]
        public IEnumerable<Car> GetCars()
        {
            return _context.Cars;
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = await _context.Cars.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }
    }
}