using System;
using Microsoft.AspNetCore.Mvc;
using Models.Exceptions;
using Models.Input;
using Repositories.Interfaces;
using Services.Interfaces;

namespace VideoTapesAPI.Controllers
{/// <summary>
 /// The controller that handles routes for friends
 /// </summary>
    public class FriendController : Controller
    {
        private readonly IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }
        
        [HttpGet]
        [Route("api/users")]
        public IActionResult GetAllFriends([FromQuery]DateTime? loanDate = null, [FromQuery]int? loanDuration = 0)
        {   // we go here if the loanDuration query parameter is set 
            if (loanDuration != 0)
            {
                return Ok(_friendService.GetLoanReportForMoreThanXDays(loanDuration));
            }
            // we go here if the loanDate query parameter is set
            if (loanDate != null)
            {
                // we go here if loanDate AND loanDuration query parameters are set
                if (loanDuration != 0)
                {
                    return Ok(_friendService.GetLoanReportForMoreThanXDaysAndDate(loanDuration, (DateTime) loanDate));
                }
                return Ok(_friendService.GetLoanReportForFriends((DateTime) loanDate));
            }
            
            return Ok(_friendService.GetAllFriends());
        }

        [HttpGet]
        [Route("api/users/{id:int}", Name = "GetFriendById")]
        public IActionResult GetFriendById(int? id)
        {
            if (id == null)
            {
                throw new ResourceNotFoundException();
            }

            return Ok(_friendService.GetFriendById((int) id));
        }

        [HttpPost]
        [Route("api/users")]
        public IActionResult AddNewFriend([FromBody]FriendInputModel friend)
        {
            Console.WriteLine(friend);
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException();
            }

            return StatusCode(201,_friendService.AddNewFriend(friend));
        }

        [HttpDelete]
        [Route("api/users/{id:int}")]
        public IActionResult DeleteFriend(int id)
        {
            _friendService.DeleteFriend(id);
            return StatusCode(204);
        }

        [HttpPut]
        [Route("api/users/{id:int}")]
        public IActionResult UpdateFriend([FromBody] FriendInputModel friend, int? id)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException();
            }

            return Ok(_friendService.UpdateFriend(friend,(int) id));
        }
    }
}