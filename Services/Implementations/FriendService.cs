using System;
using System.Collections.Generic;
using Models.Dtos;
using Models.Entity;
using Models.Input;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class FriendService : IFriendService
    {
        /// <summary>
        /// variable for the friendrepository
        /// </summary>
        private readonly IFriendRepository _friendRepository;
        
        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="friendRepository">friendrepository variable</param>
        public FriendService(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }
        
        public IEnumerable<FriendDto> GetAllFriends()
        {
            return _friendRepository.GetAllFriends();
        }

        public FriendDetailsDto GetFriendById(int id)
        {
            return _friendRepository.GetFriendById(id);
        }

        public FriendDetailsDto AddNewFriend(FriendInputModel friend)
        {
            return _friendRepository.AddNewFriend(friend);
        }

        public void DeleteFriend(int id)
        {
            _friendRepository.DeleteFriend(id);
        }

        public FriendDetailsDto UpdateFriend(FriendInputModel friend, int id)
        {
            return _friendRepository.UpdateFriend(friend, id);
        }
    }
}