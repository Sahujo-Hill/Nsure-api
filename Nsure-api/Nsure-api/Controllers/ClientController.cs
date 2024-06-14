using Microsoft.AspNetCore.Mvc;
using Nsure.api.Nsure.Models;

namespace Nsure_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

            var ClientDetails = Clients.Select(
                x 
            );
            return Ok( ClientDetails );
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
