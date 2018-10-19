using System.Collections;
using System.Collections.Generic;
using Models.Dtos;
using Models.Input;

namespace Services.Interfaces
{   /// <summary>
    /// The interface for the review service for video tapes
    /// </summary>

    public interface ITapeReviewService
    {   /// <summary>
        /// Get reviews for all the tapes
        /// </summary>
        /// <returns>List of Review dto objects for all the tapes</returns>
        IEnumerable<ReviewDto> GetReviewsForAllTapes();
        
        /// <summary>
        /// Get review for specific video tape
        /// </summary>
        /// <param name="tapeId">id for the video tape</param>
        /// <returns>review dto object</returns>
        IEnumerable<ReviewDto> GetReviewForTape(int? tapeId);
        
        /// <summary>
        /// Get review for specific tape and friend
        /// </summary>
        /// <param name="tapeId">id of the video tape</param>
        /// <param name="friendId">id of the friend</param>
        /// <returns>review dto object</returns>
        ReviewDto GetReviewForFriend(int? tapeId, int? friendId);
        
        /// <summary>
        /// updates review for specific friend and video tape
        /// </summary>
        /// <param name="tapeId">id of the video tape</param>
        /// <param name="friendId">id of the friend</param>
        /// <param name="review">input model for the updated review</param>
        /// <returns>review dto object for the updated review</returns>
        ReviewDto UpdateReviewForFriend(int? tapeId, int? friendId, ReviewInputModel review);
        
        /// <summary>
        /// deletes a review for specific friend and video tape
        /// </summary>
        /// <param name="tapeId">id of the video tape</param>
        /// <param name="friendId">id of the friend</param>
        void DeleteReviewForFriend(int? tapeId, int? friendId);
    }
}