using Microsoft.AspNetCore.Mvc;
using Models.Exceptions;
using Models.Input;
using Services.Interfaces;
using System;

namespace VideoTapesAPI.Controllers
{/// <summary>
 /// The controller that handles routes for the reviews
 /// </summary>
    public class ReviewController : Controller
    {
        private readonly ITapeReviewService _tapeReviewService;
        private readonly IFriendReviewService _friendReviewService;

        public ReviewController(ITapeReviewService tapeReviewService, IFriendReviewService friendReviewService)
        {
            _tapeReviewService = tapeReviewService;
            _friendReviewService = friendReviewService;
        }

        [HttpGet]
        [Route("api/tapes/reviews")]
        public IActionResult GetReviewsForAllTapes()
        {
            return Ok(_tapeReviewService.GetReviewsForAllTapes());
        }

        [HttpGet]
        [Route("api/tapes/{tapeId:int}/reviews")]
        public IActionResult GetReviewForTape(int? tapeId)
        {
            if (tapeId == null)
            {
                return BadRequest();
            }
            return Ok(_tapeReviewService.GetReviewForTape((int) tapeId));
        }

        [HttpGet]
        [Route("api/tapes/{tapeId:int}/reviews/{friendId:int}")]
        public IActionResult GetReviewForFriend(int? tapeId, int? friendId)
        {
            if (tapeId == null || friendId == null)
            {
                return BadRequest();
            }

            return Ok(_tapeReviewService.GetReviewForFriend(tapeId, friendId));
        }

        [HttpPut]
        [Route("api/tapes/{tapeId:int}/reviews/{friendId}")]
        public IActionResult UpdateFriendReview([FromBody] ReviewInputModel review, int? tapeId, int? friendId)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException();
            }
            if (tapeId == null || friendId == null)
            {
                return BadRequest();
            }

            return Ok(_tapeReviewService.UpdateReviewForFriend(tapeId, friendId, review));
        }

        [HttpDelete]
        [Route("api/tapes/{tapeId:int}/reviews/{friendId:int}")]
        public IActionResult DeleteFriendReview(int? tapeId, int? friendId)
        {
            if (friendId == null || tapeId == null)
            {
                return BadRequest();
            }

            _tapeReviewService.DeleteReviewForFriend(tapeId, friendId);
            return StatusCode(204);
        }

        [HttpGet]
        [Route("api/users/{friendId:int}/reviews")]
        public IActionResult GetReviewsByUserForAllTapes(int? friendId)
        {
            if (friendId == null)
            {
                return BadRequest();
            }
            return Ok(_friendReviewService.GetReviewByUserForAllTapes((int) friendId));
        }

        [HttpGet]
        [Route("api/users/{friendId:int}/reviews/{tapeId:int}")]
        public IActionResult GetReviewByUserForTape(int? friendId, int? tapeId) 
        {
            if (friendId == null || tapeId == null)
            {
                return BadRequest();
            }
            return Ok(_friendReviewService.GetReviewByUserForTape((int) friendId, (int) tapeId));
        }

        [HttpPost]
        [Route("api/users/{friendId:int}/reviews/{tapeId:int}")]
        public IActionResult AddNewReview([FromBody] ReviewInputModel review, int friendId, int tapeId)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException();
            }

            return StatusCode(201,_friendReviewService.AddNewReview((int) friendId, (int) tapeId, review));
        }

        [HttpDelete]
        [Route("api/users/{friendId:int}/reviews/{tapeId:int}")]
        public IActionResult DeleteReview(int? friendId, int? tapeId)
        {
            if (friendId == null || tapeId == null)
            {
                return BadRequest();
            }

            _friendReviewService.DeleteReview(friendId, tapeId);
            return StatusCode(204);
        }

        [HttpPut]
        [Route("api/users/{friendId:int}/reviews/{tapeId:int}")]
        public IActionResult UpdateReview([FromBody] ReviewInputModel review, int? friendId,  int? tapeId)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException();
            }
            if (tapeId == null || friendId == null)
            {
                return BadRequest();
            }

            return Ok(_friendReviewService.UpdateReview(friendId, tapeId, review));
        }
    }
}