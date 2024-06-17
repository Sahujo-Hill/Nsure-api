using Microsoft.AspNetCore.Mvc;
using Nsure.api.Nsure.Models;

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

    }
}
