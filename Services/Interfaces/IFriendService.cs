using System;
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
        
        /// <summary>
        /// Report for friends that have tapes on loan since specific date
        /// </summary>
        /// <param name="loanDate">date to query</param>
        /// <returns>list of friends dto</returns>
        IEnumerable<FriendDto> GetLoanReportForFriends(DateTime loanDate);
        
        /// <summary>
        /// Get friends that have had tapes on loan for more than X days
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