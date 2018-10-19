using System.Collections;
using System.Collections.Generic;
using Models.Dtos;
using Models.Input;

namespace Repositories.Interfaces
{/// <summary>
 /// Interface for the reviews for the video tapes
 /// </summary>
    public interface ITapeReviewRepository
    {   /// <summary>
        /// Get reviews for all video tapes
        /// </summary>
        /// <returns>List of review dto</returns>
        IEnumerable<ReviewDto> GetReviewForAllTapes();
        
        /// <summary>
        /// Get review for specific video tape
        /// </summary>
        /// <param name="tapeId">id of the video tape</param>
        /// <returns>review dto</returns>
        IEnumerable<ReviewDto> GetReviewForTape(int tapeId);
        
        /// <summary>
        /// Get review for a specific video tape and friend
        /// </summary>
        /// <param name="tapeId">id of the video tape</param>
        /// <param name="friendId">id of the friend</param>
        /// <returns>review dto</returns>
        ReviewDto GetReviewForFriend(int? tapeId, int? friendId);
        
        /// <summary>
        /// Updates review for specific video tape and friend
        /// </summary>
        /// <param name="tapeId">id of the video tape</param>
        /// <param name="friendId">id of the friend</param>
        /// <param name="review">review input model for the updated review</param>
        /// <returns>update review dto</returns>
        ReviewDto UpdateReviewForFriend(int? tapeId, int? friendId, ReviewInputModel review);
        
        /// <summary>
        /// Deletes a review for specific video tape and friend
        /// </summary>
        /// <param name="tapeId">id of the video tape</param>
        /// <param name="friendId">id of the friend</param>
        void DeleteReviewForFriend(int? tapeId, int? friendId);
    }
}