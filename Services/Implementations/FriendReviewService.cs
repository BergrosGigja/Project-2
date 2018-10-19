using System;
using System.Collections.Generic;
using Models.Dtos;
using Models.Entity;
using Models.Input;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class FriendReviewService : IFriendReviewService
    {
        private readonly IFriendReviewRepository _friendReviewsRepository;

        public FriendReviewService(IFriendReviewRepository friendReviewsRepository)
        {
            _friendReviewsRepository = friendReviewsRepository;
        }
        public IEnumerable<ReviewDto> GetReviewByUserForAllTapes(int? friendId)
        {
            return _friendReviewsRepository.GetReviewByUserForAllTapes(friendId);
        }

        public ReviewDto GetReviewByUserForTape(int? friendId, int? tapeId) 
        {
            return _friendReviewsRepository.GetReviewByUserForTape(friendId, tapeId);
        }

        public ReviewDto AddNewReview(int? friendId, int? tapeId, ReviewInputModel review)
        {
            return _friendReviewsRepository.AddNewReview(friendId, tapeId, review);
        }

        public ReviewDto UpdateReview(int? friendId, int? tapeId, ReviewInputModel review)
        {
            return _friendReviewsRepository.UpdateReview(friendId, tapeId, review);
        }

        public void DeleteReview(int? friendId, int? tapeId)
        {
            _friendReviewsRepository.DeleteReview(friendId, tapeId);
        }
    }
}