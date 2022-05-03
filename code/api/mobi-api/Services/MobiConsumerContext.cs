using Microsoft.EntityFrameworkCore;
using mobi_api.DAO;

namespace mobi_api.Services
{
    public class MobiConsumerContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<StoreEntity> Stores { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        public string DbPath { get; }

        public MobiConsumerContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "mobidbConsumer.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}