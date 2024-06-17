using Microsoft.AspNetCore.Mvc;
using Nsure.api.Nsure.Models;

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

        /*[HttpPut("{name}")]
        public IActionResult Put([FromBody] Client model)
        {
            var ClientName = _db.Clients.Find(model.Id);
            if (ClientName == null)
            {
                return NotFound();
            }
            ClientName.name = model.name;
            _db.SaveChanges();
            return Ok();
        }*/

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return Ok();
        }

    }
}
