using System;
using Microsoft.AspNetCore.Mvc;
using Models.Exceptions;
using Repositories.Interfaces;
using Services.Interfaces;

namespace VideoTapesAPI.Controllers
{
    public class TapesController : Controller
    {
        private readonly ITapeService _tapeService;

        public TapesController(ITapeService tapeService)
        {
            _tapeService = tapeService;
        }
        
        [HttpGet]
        [Route("api/tapes")]
        public IActionResult GetAllTapes()
        {
            
            return Ok(_tapeService.GetAllTapes());
        }

        [HttpGet]
        [Route("api/tapes/{id:int}", Name = "GetTapeById")]
        public IActionResult GetTapeById(int? id)
        {
            if (id == null)
            {
                throw new ResourceNotFoundException();
            }

            return Ok(_tapeService.GetTapeById((int) id));
        }
    }
}
