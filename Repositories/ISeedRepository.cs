namespace Repositories
{/// <summary>
 /// repository class for the initial seed
 /// </summary>
    public interface ISeedRepository
    {   /// <summary>
        /// seeds the database with data from the json files
        /// </summary>
        void SeedDataBase();
    }
}