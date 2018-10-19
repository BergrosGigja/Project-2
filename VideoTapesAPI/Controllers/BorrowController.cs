using System;
using Microsoft.AspNetCore.Mvc;
using Models.Exceptions;
using Models.Input;
using Repositories.Interfaces;
using Services.Interfaces;

namespace VideoTapesAPI.Controllers
{/// <summary>
 /// The controller that handles routes for loans
 /// </summary>
    public class BorrowController : Controller
    {
        private readonly ITapeService _tapeService;

        public BorrowController(ITapeService tapeService)
        {
            _tapeService = tapeService;
        }

        [HttpGet]
        [Route("api/users/{friendId:int}/tapes")]
        public IActionResult GetFriendLoans(int? friendId)
        {
            if (friendId == null)
            {
                throw new ResourceNotFoundException();
            }
            return Ok(_tapeService.GetFriendLoans(friendId));
        }
        
        [HttpPost]
        [Route("api/users/{friendId:int}/tapes/{tapeId}")]
        public IActionResult RegisterTapeLoan(int? tapeId, int? friendId)
        {

            if (friendId == null || tapeId == null)
            {
                throw new ResourceNotFoundException();
            }
            return StatusCode(201,_tapeService.RegisterTapeLoan(tapeId, friendId));
        }

        [HttpDelete]
        [Route("api/users/{friendId:int}/tapes/{tapeId}")]
        public IActionResult ReturnTape(int? tapeId, int? friendId)
        {
            _tapeService.ReturnTape(tapeId, friendId);
            return StatusCode(204);
        }

        [HttpPut]
        [Route("api/users/{friendId:int}/tapes/{tapeId}")]
        public IActionResult UpdateLoanForFriend([FromBody]BorrowInputModel borrow, int? tapeId, int? friendId)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException();
            }

            return Ok(_tapeService.UpdateLoanForFriend((int) tapeId, (int) friendId, borrow));
        }
    }
}