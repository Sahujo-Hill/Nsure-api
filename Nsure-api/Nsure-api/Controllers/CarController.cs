using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nsure.api.Nsure.Models;
using Nsure_api.DTOs;

namespace Nsure_api.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CarController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Car = _db.Cars.ToArray();

            var CarDetails = Car.Select(Car => new
            {
                Car.renewalDate,
                Car.inceptionDate,
                Car.coverTier,
                Car.reg,
                Car.make,
                Car.model,
                Car.ncbYears,
                Car.addressStored,

            });

            return Ok(CarDetails);
        }

        [HttpDelete]
        public IActionResult Delete(int Delete)
        {
            var CarID = _db.Cars.Find(Delete);
            if (CarID == null)
            {
                return NotFound();
            }
            _db.Cars.Remove(CarID);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Car Car)
        {
            _db.Cars.Add(Car);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateCar(int Id, [FromBody] UpdateCar updateCarDTO)
        {
            if (Id != updateCarDTO.Id)
            {
                return NotFound();
            }
            var CarPolicy = await _db.Cars.FindAsync(Id);
            if (CarPolicy == null)
            {
                return NotFound();
            }
            CarPolicy.coverTier = updateCarDTO.coverTier;
            CarPolicy.reg = updateCarDTO.reg;
            CarPolicy.make = updateCarDTO.make;
            CarPolicy.model = updateCarDTO.model;
            CarPolicy.ncbYears = updateCarDTO.ncbYears;
            CarPolicy.addressStored = updateCarDTO.addressStored;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_db.Clients.Any(e => e.Id == Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

    }
}
