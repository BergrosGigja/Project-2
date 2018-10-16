using System;
using Microsoft.AspNetCore.Mvc;
using Models.Exceptions;
using Models.Input;
using Repositories.Interfaces;
using Services.Interfaces;

namespace VideoTapesAPI.Controllers
{/// <summary>
 /// The controller that handles routes for tapes
 /// </summary>
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

        [HttpPost]
        [Route("api/tapes")]
        public IActionResult AddNewTape([FromBody]TapeInputModel tape)
        {
            Console.WriteLine(tape);
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException();
            }

            return StatusCode(201,_tapeService.AddNewTape(tape));
        }

        [HttpDelete]
        [Route("api/tapes/{id:int}")]
        public IActionResult DeleteTape(int id)
        {
            _tapeService.DeleteTape(id);
            return StatusCode(204);
        }

        [HttpPut]
        [Route("api/tapes/{id:int}")]
        public IActionResult UpdateTape([FromBody] TapeInputModel tape, int? id)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException();
            }

            return Ok(_tapeService.UpdateTape(tape,(int) id));
        }
    }
}
