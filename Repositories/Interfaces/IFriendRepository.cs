using System.Collections.Generic;
using Models.Dtos;
using Models.Input;

namespace Repositories.Interfaces
{/// <summary>
 /// Interface for the taperepository
 /// </summary>
    public interface IFriendRepository
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
        /// Creates new friend
        /// </summary>
        /// <param name="friend">friend input model for new friends</param>
        /// <returns>friend details dto for the new friend</returns>
        FriendDetailsDto AddNewFriend(FriendInputModel friend);

        /// <summary>
        /// deletes specific friend
        /// </summary>
        /// <param name="id">id of the friend</param>
        void DeleteFriend(int id);
        
        /// <summary>
        /// Updates specific friend
        /// </summary>
        /// <param name="friend">friend input model</param>
        /// <param name="id">id of the friend</param>
        /// <returns></returns>
        FriendDetailsDto UpdateFriend(FriendInputModel friend, int id);
        
    }
}