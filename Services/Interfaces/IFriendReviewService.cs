using System.Collections;
using System.Collections.Generic;
using Models.Dtos;
using Models.Input;

namespace Services.Interfaces
{
    public interface IFriendReviewService
    {   /// <summary>
        /// Get all reviews by a friend
        /// </summary>
        /// <param name="friendId">id of the friend</param>
        /// <returns>List of review dto</returns>
        IEnumerable<ReviewDto> GetReviewByUserForAllTapes(int? friendId);
        
        /// <summary>
        /// Get review for specific video tape by specific friend
        /// </summary>
        /// <param name="friendId">id of the friend</param>
        /// <param name="tapeId">id of the video tape</param>
        /// <returns>review dto</returns>
        ReviewDto GetReviewByUserForTape(int? friendId, int? tapeId);

        /// <summary>
        /// Creates new review for a videotape
        /// </summary>
        /// <param name="friendId">id of the friend</param>
        /// <param name="tapeId">id of the video tape</param>
        /// <param name="review">review input model for the new review</param>
        /// <returns>review dto for the new review</returns>
        ReviewDto AddNewReview(int? friendId, int? tapeId, ReviewInputModel review);
        
        /// <summary>
        /// Updates review by a friend for a specific video tape
        /// </summary>
        /// <param name="friendId">id of the friend</param>
        /// <param name="tapeId">id of the video tape</param>
        /// <param name="review">review input model for the updated review</param>
        /// <returns>update review dto</returns>
        ReviewDto UpdateReview(int? friendId, int? tapeId, ReviewInputModel review);
        
        /// <summary>
        /// Deletes a review by friend for a specific video tape
        /// </summary>
        /// <param name="friendId">id of the friend</param>
        /// <param name="tapeId">id of the video tape</param>
        void DeleteReview(int? friendId, int? tapeId);
    }
}