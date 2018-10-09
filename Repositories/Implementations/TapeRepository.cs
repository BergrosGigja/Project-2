using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models.Dtos;
using Models.Entity;
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
        Console.WriteLine(result);
        return result;
    }
    }
}