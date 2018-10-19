using System.Collections;
using System.Collections.Generic;
using Models.Dtos;
using Models.Input;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TapeReviewService : ITapeReviewService
    {
        private readonly ITapeReviewRepository _tapeReviewsRepository;

        public TapeReviewService(ITapeReviewRepository tapeReviewsRepository)
        {
            _tapeReviewsRepository = tapeReviewsRepository;
        }
        
        public IEnumerable<ReviewDto> GetReviewsForAllTapes()
        {
            return _tapeReviewsRepository.GetReviewForAllTapes();
        }

        public IEnumerable<ReviewDto> GetReviewForTape(int? tapeId)
        {
            return _tapeReviewsRepository.GetReviewForTape((int)tapeId);
        }

        public ReviewDto GetReviewForFriend(int? tapeId, int? friendId)
        {
            return _tapeReviewsRepository.GetReviewForFriend(tapeId, friendId);
        }

        public ReviewDto UpdateReviewForFriend(int? tapeId, int? friendId, ReviewInputModel review)
        {
            return _tapeReviewsRepository.UpdateReviewForFriend(tapeId, friendId, review);
        }

        public void DeleteReviewForFriend(int? tapeId, int? friendId)
        {
            _tapeReviewsRepository.DeleteReviewForFriend(tapeId, friendId);
        }
    }
}