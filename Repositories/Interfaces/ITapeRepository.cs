using System.Collections.Generic;
using Models.Dtos;
using Models.Input;


namespace Repositories.Interfaces
{/// <summary>
 /// Interface for the taperepository
 /// </summary>
    public interface ITapeRepository
    {   
        /// <summary>
        /// Get all video tapes
        /// </summary>
        /// <returns>List of all Tapes dto</returns>
        IEnumerable<TapeDto> GetAllTapes();
        
        /// <summary>
        /// Get video tape by id
        /// </summary>
        /// <param name="id">id of the video tape</param>
        /// <returns>tape details dto for the tape</returns>
        TapeDetailsDto GetTapeById(int id);
        
        /// <summary>
        /// Creates new videotape
        /// </summary>
        /// <param name="tape">tape input model for the new video tape</param>
        /// <returns>tape details dto for the new tape</returns>
        TapeDetailsDto AddNewTape(TapeInputModel tape);
        
        /// <summary>
        /// deletes specific video tape
        /// </summary>
        /// <param name="id">id of the video tape</param>
        void DeleteTape(int id);
        
        /// <summary>
        /// Updates specific video tape
        /// </summary>
        /// <param name="tape">tape input model</param>
        /// <param name="id">id of the video tape</param>
        /// <returns></returns>
        TapeDetailsDto UpdateTape(TapeInputModel tape, int id);
        
        /// <summary>
        /// Get get that the user has borrowed
        /// </summary>
        /// <param name="friendId">id of the user</param>
        /// <returns>borrow dto</returns>
        BorrowDto GetFriendLoans(int? friendId);
        
        /// <summary>
        /// Register when a friend borrowes a video tape
        /// </summary>
        /// <param name="tapeId">id of the tape</param>
        /// <param name="friendId">id of the friend</param>
        /// <returns>borrow dto</returns>
        BorrowDto RegisterTapeLoan(int? tapeId, int? friendId);
        
        /// <summary>
        /// deletes a loan for a friend
        /// </summary>
        /// <param name="tapeId">id of the tape</param>
        /// <param name="friendId">id of the friend</param>
        void DeleteFriendLoan(int? tapeId, int? friendId);

        /// <summary>
        /// updates existing loan information
        /// </summary>
        /// <param name="tapeId">id of the tape</param>
        /// <param name="friendId">id of the friend</param>
        /// <param name="borrow">borrow input model from the client</param>
        /// <returns>updated borrow dto</returns>
        BorrowDto UpdateLoanForFriend(int? tapeId, int? friendId, BorrowInputModel borrow);
    }
}