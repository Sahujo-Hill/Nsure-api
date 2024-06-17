using Microsoft.AspNetCore.Mvc;
using Nsure.api.Nsure.Models;

namespace Nsure_api.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Home = _db.Homes.ToArray();

            var HomeDetails = Home.Select(Home => new
            {
                Home.renewalDate,
                Home.inceptionDate,
                Home.coverTier,
                Home.coverType,
                Home.postcode,
                Home.addressFull,
                Home.sumInsured,
                Home.mandatoryExcess,

            });

            return Ok(HomeDetails);
        }

        [HttpDelete]
        public IActionResult Delete(int Delete)
        {
            var HomeID = _db.Homes.Find(Delete);
            if (HomeID == null)
            {
                return NotFound();
            }
            _db.Homes.Remove(HomeID);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Home Home)
        {
            _db.Homes.Add(Home);
            _db.SaveChanges();
            return Ok();
        }

    }
}
