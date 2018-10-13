using System.Collections.Generic;
using Models.Dtos;
using Models.Entity;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TapeService : ITapeService
    {
        private readonly ITapeRepository _tapeRepository;

        public TapeService(ITapeRepository tapeRepository)
        {
            _tapeRepository = tapeRepository;
        }
        
        public IEnumerable<TapeDto> GetAllTapes()
        {
            return _tapeRepository.GetAllTapes();
        }

        public TapeDetailsDto GetTapeById(int id)
        {
            return _tapeRepository.GetTapeById(id);
        }
    }
}