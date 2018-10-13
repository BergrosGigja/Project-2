using Repositories;
using Services.Interfaces;

namespace Services.Implementations
{/// <summary>
    /// The class for seeding the database in the beginning
    /// </summary>
    public class SeedService : ISeedService
    {   /// <summary>
        /// seed repository variable
        /// </summary>
        private readonly ISeedRepository _seedRepository;

        /// <summary>
        /// constructor for the class
        /// </summary>
        /// <param name="seedRepository">seedrepository variable</param>
        public SeedService(ISeedRepository seedRepository)
        {
            _seedRepository = seedRepository;
        }

        /// <summary>
        /// seeds the database with data from the json files
        /// </summary>
        public void SeedDataBase()
        {
            _seedRepository.SeedDataBase();
        }
    }
}