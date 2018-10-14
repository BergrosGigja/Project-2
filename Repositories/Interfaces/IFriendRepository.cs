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
        
    }
}