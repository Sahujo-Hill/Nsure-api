using Microsoft.AspNetCore.Mvc;
using Nsure.api.Nsure.Models;

namespace Nsure_api.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class LifeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public LifeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Life = _db.Life.ToArray();

            var LifeDetails = Life.Select(Life => new
            {
                Life.renewalDate,
                Life.inceptionDate,
                Life.coverTier,
                Life.nameInsured,
                Life.coverType,
                Life.benefitAmount,
                Life.benefitPeriod,
                Life.basisOfAdvice,

            });

            return Ok(LifeDetails);
        }

        [HttpDelete]
        public IActionResult Delete(int Delete)
        {
            var LifeID = _db.Life.Find(Delete);
            if (LifeID == null)
            {
                return NotFound();
            }
            _db.Life.Remove(LifeID);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Life Life)
        {
            _db.Life.Add(Life);
            _db.SaveChanges();
            return Ok();
        }

    }
}
