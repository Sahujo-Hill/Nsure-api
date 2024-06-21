using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nsure.api.Nsure.Models;
using Nsure_api.DTOs;

namespace Nsure_api.Controllers
{
    [ApiController]
    [Route("[controller]")]


    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClientController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var Clients = _db.Clients.ToArray();

            var ClientDetails = Clients.Select(Clients => new
            {
                Clients.name,
                Clients.carPolicy,
                Clients.homePolicy,
                Clients.lifePolicy,

            });

            return Ok(ClientDetails);
        }

        [HttpDelete]
        public IActionResult Delete(int Delete)
        {
            var ClientId = _db.Clients.Find(Delete);
            if (ClientId == null)
            {
                return NotFound();
            }
            _db.Clients.Remove(ClientId);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser(int Id, [FromBody] UpdateUser updateUserDTO)
        {
            if (Id != updateUserDTO.Id)
            {
                return NotFound();
            }
            var user = await _db.Clients.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            user.name = updateUserDTO.name;
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
