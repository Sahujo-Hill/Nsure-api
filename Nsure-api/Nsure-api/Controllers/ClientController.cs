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
                Clients.policies

            });

            return Ok(ClientDetails);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return Ok();
        }

    }
}
