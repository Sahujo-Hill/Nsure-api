using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nsure.api.Nsure.Models;
using Nsure_api.DTOs;

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

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateHome(int Id, [FromBody] UpdateHome updateHomeDTO)
        {
            // Check if the Id in the URL matches the Id in the body
            if (Id != updateHomeDTO.Id)
            {
                return NotFound();
            }

            // Find the home policy by Id
            var HomePolicy = await _db.Homes.FindAsync(Id);
            if (HomePolicy == null)
            {
                return NotFound();
            }

            // Update the home policy with values from the DTO
            HomePolicy.coverTier = updateHomeDTO.coverTier;
            HomePolicy.coverType = updateHomeDTO.coverType;
            HomePolicy.postcode = updateHomeDTO.postcode;
            HomePolicy.addressFull = updateHomeDTO.addressFull;
            HomePolicy.sumInsured = updateHomeDTO.sumInsured;
            HomePolicy.mandatoryExcess = updateHomeDTO.mandatoryExcess;

            // Try to save changes
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // If an exception occurs, check if the client still exists
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
