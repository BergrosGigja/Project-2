using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using Models.Dtos;
using Models.Entity;
using Models.Exceptions;
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
        
    }
}