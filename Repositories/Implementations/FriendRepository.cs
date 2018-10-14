using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
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
        
    }
}