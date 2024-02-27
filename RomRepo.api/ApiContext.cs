using Microsoft.EntityFrameworkCore;
using RomRepo.api.Models;

namespace RomRepo.api
{
    public class ApiContext : DbContext
    {
        public DbSet<ApiKey> ApiKey { get; set; }
        public DbSet<GameSystem> GameSystem { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Rom> Rom { get; set; }

        public string DbPath { get; }

        public ApiContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            string subfolder = "\\RomRepo";

            if (!Directory.Exists(path + subfolder))
            {
                Directory.CreateDirectory(path + subfolder);
            }

            DbPath = System.IO.Path.Join(path + subfolder + "\\", "romrepo.api.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
