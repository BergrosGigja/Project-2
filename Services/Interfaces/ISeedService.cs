namespace Services.Interfaces
{/// <summary>
 /// The interface for seeding the database in the beginning
 /// </summary>
    public interface ISeedService
    {   /// <summary>
        /// Seeds the database from data from the json files
        /// </summary>
        void SeedDataBase();
    }
}