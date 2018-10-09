using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using Services.Interfaces;

namespace VideoTapesAPI.Controllers
{
    public class SeedDbController : Controller
    {
        private readonly ISeedService _seedService;

        public SeedDbController(ISeedService seedService)
        {
            _seedService = seedService;
        }

        [HttpPost]
        [Route("api/seed")]
        public IActionResult SeedDataBase()
        {
            _seedService.SeedDataBase();
            return Ok();
        }
    }
}