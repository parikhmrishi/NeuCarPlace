using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeuCarPlace.Domain.Contexts;
using NeuCarPlace.Domain.Entities;
using NeuCarPlace.Services.DTOs;

namespace NeuCarPlace.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly NeuCarPlaceDbContext _context;

        public PurchasesController(NeuCarPlaceDbContext context)
        {
            _context = context;
        }

        // GET: api/Purchases/something@gmail.com
        [HttpGet("{email}")]
        public async Task<IActionResult> getMyPurchase([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carIdList = _context.Purchases.Where(u => u.UserId == email).Select(e => e.CarId).ToList();

            if (carIdList == null)
            {
                return NotFound();
            }
            List<PurchasesDTO> carDetails = new List<PurchasesDTO>();
            var carDetail = _context.Cars.Where(e => carIdList.Contains(e.Id)).ToList();

            foreach (var thisCar in carDetail)
            {
                PurchasesDTO data = new PurchasesDTO();
                data.CarId = thisCar.Id;
                data.ModelName = thisCar.ModelName;
                data.Image = thisCar.Image;
                data.LaunchDate = thisCar.LaunchDate;
                data.Price = thisCar.Price;
                carDetails.Add(data);
            }
            await _context.SaveChangesAsync();


            return Ok(carDetails);
        
    }

        [HttpGet("{email}/{carId}")]
        public Boolean checkPurchase([FromRoute] string email, int carId)
        {
            return _context.Purchases.Any(e => e.CarId == carId && e.UserId == email);

        }

        // POST: api/Purchases
        [HttpPost]
        public async Task<IActionResult> postPurchase([FromBody] Purchase purchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            purchase.DateOfBooking = DateTime.Now;
            _context.Purchases.Add(purchase);
            await _context.SaveChangesAsync();

            return Ok(purchase);
        }

        // DELETE: api/Purchases/5
        [HttpDelete("{email}/{carId}")]
        public async Task<IActionResult> deletePurchase([FromRoute]string email, int carId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var purchase = await _context.Purchases.FirstOrDefaultAsync(u=> u.UserId == email && u.CarId == carId);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return Ok(purchase);
        }

        private bool PurchaseExists(int id)
        {
            return _context.Purchases.Any(e => e.Id == id);
        }
    }
}