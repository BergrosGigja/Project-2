using System.Collections.Generic;
using Models.Dtos;


namespace Repositories.Interfaces
{
    public interface ITapeRepository
    {
        IEnumerable<TapeDto> GetAllTapes();
        TapeDetailsDto GetTapeById(int id);
    }
}