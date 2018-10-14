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
    }
}