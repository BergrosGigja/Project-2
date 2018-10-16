using System.Collections;
using System.Collections.Generic;
using Models.Dtos;
using Models.Entity;
using Models.Input;

namespace Services.Interfaces
{
    public interface IFriendService
    {
         /// <summary>
        /// Get all friends
        /// </summary>
        /// <returns>List of all Friends dto</returns>
        IEnumerable<FriendDto> GetAllFriends();

        /// <summary>
        /// Get friend by id
        /// </summary>
        /// <param name="id">id of the friend</param>
        /// <returns>friend details dto for the friend</returns>
        FriendDetailsDto GetFriendById(int id);

        /// <summary>
        /// Adds a new friend
        /// </summary>
        /// <param name="friend">Is the input model for the new friend</param>
        /// <returns>returns the new friend details dto object</returns>
        FriendDetailsDto AddNewFriend(FriendInputModel friend);

        /// <summary>
        /// Deletes a friend
        /// </summary>
        /// <param name="id">id of the friend</param>
        void DeleteFriend(int id);

        /// <summary>
        /// Updates existing friend
        /// </summary>
        /// <param name="friend">Is the input model for the changes to be made</param>
        /// <param name="id">Is the id of the friend</param>
        /// <returns>Updated friend details dto object</returns>
        FriendDetailsDto UpdateFriend(FriendInputModel friend, int id);
    }
}