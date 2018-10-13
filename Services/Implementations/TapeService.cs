using System.Collections.Generic;
using Models.Dtos;
using Models.Entity;
using Models.Input;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TapeService : ITapeService
    {
        /// <summary>
        /// variable for the taperepository
        /// </summary>
        private readonly ITapeRepository _tapeRepository;
        
        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="tapeRepository">taperepository variable</param>
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

        public TapeDetailsDto AddNewTape(TapeInputModel tape)
        {
            return _tapeRepository.AddNewTape(tape);
        }

        public void DeleteTape(int id)
        {
            _tapeRepository.DeleteTape(id);
        }

        public TapeDetailsDto UpdateTape(TapeInputModel tape, int id)
        {
            return _tapeRepository.UpdateTape(tape, id);
        }
    }
}