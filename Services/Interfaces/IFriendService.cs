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
    }
}