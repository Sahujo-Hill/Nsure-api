using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nsure.api.Nsure.Models;
using Nsure_api.DTOs;

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

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateLife(int Id, [FromBody] UpdateLife updateLifeDTO)
        {
            if (Id != updateLifeDTO.Id)
            {
                return NotFound();
            }
            var LifePolicy = await _db.Life.FindAsync(Id);
            if (LifePolicy == null)
            {
                return NotFound();
            }
            LifePolicy.coverTier = updateLifeDTO.coverTier;
            LifePolicy.nameInsured = updateLifeDTO.nameInsured;
            LifePolicy.coverType = updateLifeDTO.coverType;
            LifePolicy.benefitAmount = updateLifeDTO.benefitAmount;
            LifePolicy.benefitPeriod = updateLifeDTO.benefitPeriod;
            LifePolicy.basisOfAdvice = updateLifeDTO.basisOfAdvice;
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
