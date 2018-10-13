using System.Collections;
using System.Collections.Generic;
using Models.Dtos;
using Models.Entity;
using Models.Input;

namespace Services.Interfaces
{/// <summary>
 /// The interface for the tape service
 /// </summary>
    public interface ITapeService
    {   /// <summary>
        /// Get all video tapes
        /// </summary>
        /// <returns>returns Dto objects for all tapes</returns>
        IEnumerable<TapeDto> GetAllTapes();
        /// <summary>
        /// Get video tape by id
        /// </summary>
        /// <param name="id">id of the video tape</param>
        /// <returns></returns>
        TapeDetailsDto GetTapeById(int id);
        /// <summary>
        /// Adds a new video tape
        /// </summary>
        /// <param name="tape">Is the input model for the new tape</param>
        /// <returns>returns the new video tape details dto object</returns>
        TapeDetailsDto AddNewTape(TapeInputModel tape);
        /// <summary>
        /// Deletes a video tape
        /// </summary>
        /// <param name="id">id of the video tape</param>
        void DeleteTape(int id);
        /// <summary>
        /// Updates existing video tape
        /// </summary>
        /// <param name="tape">Is the input model for the changes to be made</param>
        /// <param name="id">Is the id of the video tape</param>
        /// <returns>Updated tape details dto object</returns>
        TapeDetailsDto UpdateTape(TapeInputModel tape, int id);
    }
}