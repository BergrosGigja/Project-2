using System;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;

namespace VideoTapesAPI.Controllers
{
    public class TapesController : Controller
    {
        private readonly ITapeRepository _tapeRepository;

        public TapesController(ITapeRepository tapeRepository)
        {
            _tapeRepository = tapeRepository;
        }
        
        [HttpGet]
        [Route("api/tapes")]
        public IActionResult GetAllTapes()
        {
            Console.WriteLine("printing stuff here!!!");
            Console.WriteLine(_tapeRepository.GetAllTapes());
            
            return Ok(_tapeRepository.GetAllTapes());
        }
    }
}
