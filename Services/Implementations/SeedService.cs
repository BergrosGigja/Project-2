using Repositories;
using Services.Interfaces;

namespace Services.Implementations
{
    public class SeedService : ISeedService
    {
        private readonly ISeedRepository _seedRepository;

        public SeedService(ISeedRepository seedRepository)
        {
            _seedRepository = seedRepository;
        }

        public void SeedDataBase()
        {
            _seedRepository.SeedDataBase();
        }
    }
}