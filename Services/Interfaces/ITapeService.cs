using System.Collections;
using System.Collections.Generic;
using Models.Dtos;
using Models.Entity;

namespace Services.Interfaces
{
    public interface ITapeService
    {
        IEnumerable<TapeDto> GetAllTapes();
    }
}