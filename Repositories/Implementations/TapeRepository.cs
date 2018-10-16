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
    public class TapeRepository : ITapeRepository

    {
    private readonly DataBaseContext _dataBaseContext;


    public TapeRepository(DataBaseContext db)
    {
        _dataBaseContext = db;
    }

    public IEnumerable<TapeDto> GetAllTapes()
    {
        var tapesEntity = _dataBaseContext.Tapes.ToList();
        var result = Mapper.Map<IList<Tape>, IList<TapeDto>>(tapesEntity);
        return result;
    }

    public TapeDetailsDto GetTapeById(int id)
    {
        var tapeDtos = (from t in _dataBaseContext.Tapes
            where id == t.Id
            select new TapeDetailsDto
            {
                Id = t.Id,
                DirectorName = t.DirectorName,
                Eidr = t.Eidr,
                ReleaseDate = t.ReleaseDate,
                Title = t.Title,
                Type = t.Type,
                AverageRating = t.AverageRating,
                BorrowHistory = (from b in _dataBaseContext.Borrows
                    where b.Id == t.Id
                    select new BorrowDto
                    {
                        BorrowDate = b.BorrowDate,
                        FriendId = b.FriendId,
                        ReturnDate = b.ReturnDate,
                        TapeId = t.Id,
                     }).ToList()
             }).ToList().FirstOrDefault();
        if (tapeDtos == null)
        {
            throw new ResourceNotFoundException();
        }

        return tapeDtos;
        }

        public TapeDetailsDto AddNewTape(TapeInputModel tape)
        {
            var tapeEntity = Mapper.Map<Tape>(tape);
            _dataBaseContext.Tapes.Add(tapeEntity);
            _dataBaseContext.SaveChanges();
            var tapeDto = Mapper.Map<TapeDetailsDto>(tapeEntity);
            return tapeDto;
        }

        public void DeleteTape(int id)
        {
            var tapeEntity = (from t in _dataBaseContext.Tapes where id == t.Id select t).FirstOrDefault();
            if (tapeEntity == null)
            {
                throw new ResourceNotFoundException();
            }

            _dataBaseContext.Remove(tapeEntity);
            _dataBaseContext.SaveChanges();
        }

        public TapeDetailsDto UpdateTape(TapeInputModel tape, int id)
        {
            var tapeEntity = (from t in _dataBaseContext.Tapes where id == t.Id select t).FirstOrDefault();
            if (tapeEntity == null)
            {
                throw new ResourceNotFoundException();
            }

            // update the tape with the info given
            tapeEntity.Eidr = tape.Eidr;
            tapeEntity.Title = tape.Title;
            tapeEntity.Type = tape.Type;
            tapeEntity.DirectorName = tape.DirectorName;
            tapeEntity.ReleaseDate = tape.ReleaseDate;
            // database specific
            tapeEntity.DateModified = DateTime.Now;
            _dataBaseContext.SaveChanges();
            // return the updated tape
            var tapeDetailsDto = Mapper.Map<TapeDetailsDto>(tapeEntity);
            return tapeDetailsDto;
        }

        public BorrowDto GetFriendLoans(int? friendId)
        {
            // check if user exists
            var friendEntity = (from b in _dataBaseContext.Friends where friendId == b.Id select b).FirstOrDefault();
            if (friendEntity == null)
            {
                throw new ResourceNotFoundException();
            }
            // get loans
            var borrowEntity = (from b in _dataBaseContext.Borrows where friendId == b.FriendId select b).ToList();
            var borrowDto = Mapper.Map<BorrowDto>(borrowEntity);
            return borrowDto;
        }

        public BorrowDto RegisterTapeLoan(int? tapeId, int? friendId)
        {
            CheckIfUserOrTapeExist(tapeId,friendId);
            var borrowEntity = new Borrow
            {
                BorrowDate = DateTime.Now,
                FriendId = (int) friendId,
                TapeId = (int) tapeId,
                ReturnDate = null
            };
            _dataBaseContext.Borrows.Add(borrowEntity);
            _dataBaseContext.SaveChanges();
            var borrowDto = Mapper.Map<BorrowDto>(borrowEntity);
            return borrowDto;
        }

        public void DeleteFriendLoan(int? tapeId, int? friendId)
        {
            var borrowEntity = (from b in _dataBaseContext.Borrows
                where tapeId == b.TapeId && friendId == b.FriendId
                select b).FirstOrDefault();

            if (borrowEntity == null)
            {
                throw new ResourceNotFoundException();
            }

            _dataBaseContext.Remove(borrowEntity);
            _dataBaseContext.SaveChanges();
        }

        public BorrowDto UpdateLoanForFriend(int? tapeId, int? friendId, BorrowInputModel borrow)
        {
            CheckIfUserOrTapeExist(tapeId,friendId);
            var borrowEntity = (from b in _dataBaseContext.Borrows
                where friendId == b.FriendId && tapeId == b.TapeId
                select b).FirstOrDefault();
            if (borrowEntity == null)
            {
                throw new ResourceNotFoundException();
            }
            
            // update the borrow information
            borrowEntity.BorrowDate = borrow.BorrowDate;
            borrowEntity.FriendId = borrow.FriendId;
            borrowEntity.ReturnDate = borrow.ReturnDate;
            _dataBaseContext.SaveChanges();
            
            // return update borrow dto
            var borrowDto = Mapper.Map<BorrowDto>(borrowEntity);
            return borrowDto;
        }

        // private method to check if tape or user exists
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