using System;
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

        /// <summary>
        /// Report for friends that have tapes on loan since specific date
        /// </summary>
        /// <param name="loanDate">date to query</param>
        /// <returns>list of friends dto</returns>
        IEnumerable<FriendDto> GetLoanReportForFriends(DateTime loanDate);

        /// <summary>
        /// Get user that have had tapes on loan for more than X days
        /// </summary>
        /// <param name="loanDuration">how many days</param>
        /// <returns>list of friend dto</returns>
        IEnumerable<FriendDto> GetLoanReportForMoreThanXDays(int? loanDuration);
           
        /// <summary>
        /// Get friends that have had tapes on loan for more than x days as of specific date
        /// </summary>
        /// <param name="loanDuration">duration to query for</param>
        /// <param name="loanDate">date to query for</param>
        /// <returns>list of friend dto</returns>
        IEnumerable<FriendDto> GetLoanReportForMoreThanXDaysAndDate(int? loanDuration, DateTime loanDate);

    }
}