using Microsoft.AspNetCore.Mvc;
using Models.Exceptions;
using Models.Input;
using Services.Interfaces;

namespace VideoTapesAPI.Controllers
{/// <summary>
 /// The controller that handles routes for the reviews
 /// </summary>
    public class ReviewController : Controller
    {
        private readonly ITapeReviewService _tapeReviewService;

        public ReviewController(ITapeReviewService tapeReviewService)
        {
            _tapeReviewService = tapeReviewService;
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
    }
}