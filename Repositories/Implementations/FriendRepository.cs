using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.Dtos;
using Models.Entity;
using Models.Exceptions;
using Models.Input;
using Remotion.Linq.Clauses;
using Repositories.Interfaces;



namespace Repositories.Implementations
{
    public class FriendRepository : IFriendRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public FriendRepository(DataBaseContext db)
        {
            _dataBaseContext = db;
        }

        public IEnumerable<FriendDto> GetAllFriends()
        {
            var friendsEntity = _dataBaseContext.Friends.ToList();
            var result = Mapper.Map<IList<Friend>, IList<FriendDto>>(friendsEntity);
            return result;
        }

        public FriendDetailsDto GetFriendById(int id)
        {
            var friendDtos = (from f in _dataBaseContext.Friends
            where id == f.Id
            select new FriendDetailsDto
            {
                Id = f.Id,
                Name = f.Name,
                Email = f.Email,
                Phone = f.Phone,
                Address = f.Address,
                Tapes = (from b in _dataBaseContext.Borrows
                    where b.FriendId == f.Id
                    select new BorrowDto
                    {
                        BorrowDate = b.BorrowDate,
                        FriendId = f.Id,
                        ReturnDate = b.ReturnDate,
                        TapeId = b.TapeId,
                     }).ToList()
             }).ToList().FirstOrDefault();
            if (friendDtos == null)
            {
                throw new ResourceNotFoundException();
            }
            
            return friendDtos;
        }

        public FriendDetailsDto AddNewFriend(FriendInputModel friend)
        {
            var friendEntity = Mapper.Map<Friend>(friend);
            _dataBaseContext.Friends.Add(friendEntity);
            _dataBaseContext.SaveChanges();
            var friendDto = Mapper.Map<FriendDetailsDto>(friendEntity);
            return friendDto;
        }

        public void DeleteFriend(int id)
        {
            var friendEntity = (from f in _dataBaseContext.Friends where id == f.Id select f).FirstOrDefault();
            if (friendEntity == null)
            {
                throw new ResourceNotFoundException();
            }

            _dataBaseContext.Remove(friendEntity);
            _dataBaseContext.SaveChanges();
        }

        public FriendDetailsDto UpdateFriend(FriendInputModel friend, int id)
        {
            var friendEntity = (from f in _dataBaseContext.Friends where id == f.Id select f).FirstOrDefault();
            if (friendEntity == null)
            {
                throw new ResourceNotFoundException();
            }

            // update the friend with the info given
            friendEntity.Name = friend.Name;
            friendEntity.Email = friend.Email;
            friendEntity.Phone = friend.Phone;
            friendEntity.Address = friend.Address;
            // database specific
            friendEntity.DateModified = DateTime.Now;
            _dataBaseContext.SaveChanges();
            // return the updated friend
            var friendDetailsDto = Mapper.Map<FriendDetailsDto>(friendEntity);
            return friendDetailsDto;
        }

        public IEnumerable<FriendDto> GetLoanReportForFriends(DateTime loanDate)
        {
            var friendEntities = (from f in _dataBaseContext.Friends
                join b in _dataBaseContext.Borrows on
                    f.Id equals b.FriendId
                where loanDate >= b.BorrowDate && (b.ReturnDate == null || loanDate < b.ReturnDate)
                select f).ToList();
            
            var friendDto = Mapper.Map<IList<Friend>, IList<FriendDto>>(friendEntities);
            return friendDto;
        }

        public IEnumerable<FriendDto> GetLoanReportForMoreThanXDays(int? loanDuration)
        {
            
            var lstfriends = (from b in _dataBaseContext.Friends select b).ToList();
            var lstborrow = (from b in _dataBaseContext.Borrows select b).ToList();
            var friendEndities = (from f in lstfriends
                join b in lstborrow on
                    f.Id equals b.FriendId
                where b.ReturnDate == null &&
                      loanDuration < DateTime.Now.Subtract(b.BorrowDate).TotalDays
                select f).Distinct().ToList();
            
        
            var friendDto = Mapper.Map<IList<Friend>, IList<FriendDto>>(friendEndities);
            return friendDto;

        }

        public IEnumerable<FriendDto> GetLoanReportForMoreThanXDaysAndDate(int? loanDuration, DateTime loanDate)
        {
            var friends = (from f in _dataBaseContext.Friends select f).ToList();
            var borrow = (from b in _dataBaseContext.Borrows select b).ToList();
            var friendEntities = (from f in friends
                join b in borrow on
                    f.Id equals b.FriendId
                where loanDate >= b.BorrowDate && loanDuration < (loanDate - b.BorrowDate).TotalDays &&
                      (b.ReturnDate == null || loanDate < b.ReturnDate)
                select f).Distinct().ToList();
            
            var friendDto = Mapper.Map<IList<Friend>, IList<FriendDto>>(friendEntities);
            return friendDto;
            
        }
    }
}