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
        [Route("api/friends")]
        public IActionResult GetAllFriends()
        {
            
            return Ok(_friendService.GetAllFriends());
        }

        [HttpGet]
        [Route("api/friends/{id:int}", Name = "GetFriendById")]
        public IActionResult GetFriendById(int? id)
        {
            if (id == null)
            {
                throw new ResourceNotFoundException();
            }

            return Ok(_friendService.GetFriendById((int) id));
        }

        [HttpPost]
        [Route("api/friends")]
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
        [Route("api/friends/{id:int}")]
        public IActionResult DeleteFriend(int id)
        {
            _friendService.DeleteFriend(id);
            return StatusCode(204);
        }

        [HttpPut]
        [Route("api/friends/{id:int}")]
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