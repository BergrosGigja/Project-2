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
    public class TapeReviewRepository : ITapeReviewRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public TapeReviewRepository(DataBaseContext db)
        {
            _dataBaseContext = db;
        }
        
        public IEnumerable<ReviewDto> GetReviewForAllTapes()
        {
            var reviewEntity = _dataBaseContext.Reviews.ToList();
            var reviewDto = Mapper.Map<IList<Review>, IList<ReviewDto>>(reviewEntity);
            return reviewDto;
        }

        public ReviewDto GetReviewForTape(int tapeId)
        {
            // first check if tape exists
            var tapeEntity = (from t in _dataBaseContext.Tapes where tapeId == t.Id select t).FirstOrDefault();
            if (tapeEntity == null)
            {
                throw new ResourceNotFoundException();
            }
            var reviewEntity = (from r in _dataBaseContext.Reviews where tapeId == r.TapeId select r).FirstOrDefault();

            var reviewDto = Mapper.Map<ReviewDto>(reviewEntity);
            return reviewDto;
        }

        public ReviewDto GetReviewForFriend(int? tapeId, int? friendId)
        {
            CheckIfUserOrTapeExist(tapeId, friendId);
            
            var reviewEntity = (from r in _dataBaseContext.Reviews
                where friendId == r.Id && tapeId == r.TapeId
                select r).FirstOrDefault();

            var reviewDto = Mapper.Map<ReviewDto>(reviewEntity);
            return reviewDto;
        }

        public ReviewDto UpdateReviewForFriend(int? tapeId, int? friendId, ReviewInputModel review)
        {
            CheckIfUserOrTapeExist(tapeId, friendId);

            var reviewEntity = (from r in _dataBaseContext.Reviews
                where tapeId == r.TapeId && friendId == r.FriendId
                select r).FirstOrDefault();

            if (reviewEntity == null)
            {
                throw new ResourceNotFoundException();
            }
             
            // make the changes
            reviewEntity.ReviewInput = review.ReviewInput;
            //database specific
            reviewEntity.DateModified = DateTime.Now;
            _dataBaseContext.SaveChanges();

            var reviewDto = Mapper.Map<ReviewDto>(reviewEntity);
            return reviewDto;
        }

        public void DeleteReviewForFriend(int? tapeId, int? friendId)
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
    }
}