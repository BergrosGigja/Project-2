using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models.Dtos;
using Models.Entity;
using Models.Exceptions;
using Models.Input;
using Repositories.Interfaces;

namespace Repositories.Implementations
{
    public class FriendReviewRepository : IFriendReviewRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public FriendReviewRepository(DataBaseContext db)
        {
            _dataBaseContext = db;
        }
        
        public IEnumerable<ReviewDto> GetReviewByUserForAllTapes(int? friendId)
        {
            var friendEntity = (from f in _dataBaseContext.Friends where friendId == f.Id select f).FirstOrDefault();
            if (friendEntity == null)
            {
                throw new ResourceNotFoundException();
            }
            var reviewEntity = (from r in _dataBaseContext.Reviews where friendId == r.FriendId select r).ToList();
            var reviewDto = Mapper.Map<IList<Review>, IList<ReviewDto>>(reviewEntity);
            return reviewDto;
        }

        public ReviewDto GetReviewByUserForTape(int? friendId, int? tapeId)
        {
            CheckIfUserOrTapeExist(tapeId, friendId);
            
            var reviewEntity = (from r in _dataBaseContext.Reviews
                where friendId == r.FriendId && tapeId == r.TapeId
                select r).FirstOrDefault();

            var reviewDto = Mapper.Map<ReviewDto>(reviewEntity);
            return reviewDto;
        }

        public ReviewDto AddNewReview(int? friendId, int? tapeId, ReviewInputModel review)
        {
            CheckIfUserOrTapeExist(tapeId, friendId);

            var reviewEntity = new Review
            {
                FriendId = (int) friendId,
                TapeId = (int) tapeId,
                Rating = (int) review.Rating,
                ReviewInput = review.ReviewInput
            };

            _dataBaseContext.Reviews.Add(reviewEntity);
            _dataBaseContext.SaveChanges();
            var reviewDto = Mapper.Map<ReviewDto>(reviewEntity);
            updateTapeRating(tapeId);
            return reviewDto;
        }

        public ReviewDto UpdateReview(int? friendId, int? tapeId, ReviewInputModel review)
        {
            CheckIfUserOrTapeExist(tapeId, friendId);

            var reviewEntity = (from r in _dataBaseContext.Reviews
                where tapeId == r.TapeId && friendId == r.FriendId
                select r).FirstOrDefault();

            if (reviewEntity == null)
            {
                throw new ResourceNotFoundException();
            };

            // make the changes
            reviewEntity.Rating = review.Rating;
            reviewEntity.ReviewInput = review.ReviewInput;
            // database specific
            reviewEntity.DateModified = DateTime.Now;
            _dataBaseContext.SaveChanges();
            // return the updated friend
            var reviewDto = Mapper.Map<ReviewDto>(reviewEntity);
            updateTapeRating(tapeId);
            return reviewDto;
        }

        public void DeleteReview(int? friendId, int? tapeId)
        {
            CheckIfUserOrTapeExist(tapeId, friendId);

            var reviewEntity = (from r in _dataBaseContext.Reviews
                where tapeId == r.TapeId && friendId == r.FriendId
                select r).FirstOrDefault();

            if (reviewEntity == null)
            {
                throw new ResourceNotFoundException();
            }

            _dataBaseContext.Reviews.Remove(reviewEntity);
            _dataBaseContext.SaveChanges();
            updateTapeRating(tapeId);
        }

        private void CheckIfUserOrTapeExist(int? tapeId, int? friendId)
        {
            // first check if friend or tape exists
            var friendEntity = (from f in _dataBaseContext.Friends where friendId == f.Id select f).FirstOrDefault();
            var tapeEntity = (from t in _dataBaseContext.Tapes where tapeId == t.Id select t).FirstOrDefault();
            if (friendEntity == null || tapeEntity == null)
            {
                throw new ResourceNotFoundException();
            }
        }

        private void updateTapeRating(int? tapeId)
        {
            var ratings = (from r in _dataBaseContext.Reviews where tapeId == r.TapeId select r.Rating).ToList();
            var average = ratings.Count > 0 ? ratings.Average() : 0.0;
            average = Math.Round((double)average, 2);

            var tapeEntity = (from t in _dataBaseContext.Tapes where tapeId == t.Id select t).FirstOrDefault();
            if (tapeEntity == null)
            {
                throw new ResourceNotFoundException();
            }

            // update the tape with the info given
            tapeEntity.AverageRating = average;
            // database specific
            tapeEntity.DateModified = DateTime.Now;
            _dataBaseContext.SaveChanges();
            // return the updated tape
            var tapeDetailsDto = Mapper.Map<TapeDetailsDto>(tapeEntity);
        }
    }
}