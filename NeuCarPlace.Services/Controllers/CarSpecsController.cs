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
    public class CarSpecsController : ControllerBase
    {
        private readonly NeuCarPlaceDbContext _context;

        public CarSpecsController(NeuCarPlaceDbContext context)
        {
            _context = context;
        }

        // GET: api/CarSpecs
        [HttpGet]
        public IEnumerable<CarSpec> GetCarSpecs()
        {
            return _context.CarSpecs;
        }

        // GET: api/CarSpecs/5
        [HttpGet("{carId}")]
        public async Task<IActionResult> GetCarSpec([FromRoute] int carId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carSpec = await _context.CarSpecs.FirstAsync(u => u.CarId == carId);

            if (carSpec == null)
            {
                return NotFound();
            }

            return Ok(carSpec);
        }

        // PUT: api/CarSpecs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarSpec([FromRoute] int id, [FromBody] CarSpec carSpec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carSpec.Id)
            {
                return BadRequest();
            }

            _context.Entry(carSpec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarSpecExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarSpecs
        [HttpPost]
        public async Task<IActionResult> PostCarSpec([FromBody] CarSpec carSpec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CarSpecs.Add(carSpec);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarSpec", new { id = carSpec.Id }, carSpec);
        }

        // DELETE: api/CarSpecs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarSpec([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carSpec = await _context.CarSpecs.FindAsync(id);
            if (carSpec == null)
            {
                return NotFound();
            }

            _context.CarSpecs.Remove(carSpec);
            await _context.SaveChangesAsync();

            return Ok(carSpec);
        }

        private bool CarSpecExists(int id)
        {
            return _context.CarSpecs.Any(e => e.Id == id);
        }
    }
}