using Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Repositories.Implementations
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
            
        }

        public DataBaseContext(DbContextOptions<DbContext> options) : base(options)
        {
            
        }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=../Repositories/VideoTapesGalore.db");
        }
        
        public virtual DbSet<Tape> Tapes { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }
    }
}