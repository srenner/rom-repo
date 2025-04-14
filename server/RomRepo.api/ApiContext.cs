using Microsoft.EntityFrameworkCore;
using RomRepo.api.Models;

namespace RomRepo.api
{
    /// <summary>
    /// Database context for the API
    /// </summary>
    public class ApiContext : DbContext
    {
        /// <summary>
        /// Database table <see cref="ApiKey"/>
        /// </summary>
        public DbSet<ApiKey> ApiKey { get; set; }
        /// <summary>
        /// Database table <see cref="GameSystem"/>
        /// </summary>
        public DbSet<GameSystem> GameSystem { get; set; }
        /// <summary>
        /// Database table <see cref="Game"/>
        /// </summary>
        public DbSet<Game> Game { get; set; }
        /// <summary>
        /// Database table <see cref="Rom"/>
        /// </summary>
        public DbSet<Rom> Rom { get; set; }
        /// <summary>
        /// Database table <see cref="GameAttribute"/>
        /// </summary>
        public DbSet<GameAttribute> GameAttribute { get; set; }
        /// <summary>
        /// Database table <see cref="GameFavorite"/>
        /// </summary>
        public DbSet<GameFavorite> GameFavorite { get; set; }
        /// <summary>
        /// Database table <see cref="GameSystemFavorite"/>
        /// </summary>
        public DbSet<GameSystemFavorite> GameSystemFavorite { get; set; }
        /// <summary>
        /// Database table <see cref="GameInstallation"/>
        /// </summary>
        public DbSet<GameInstallation> GameInstallation { get; set; }

        /// <summary>
        /// Path to the database file
        /// </summary>
        public string DbPath { get; }

        /// <summary>Constructor</summary>
        public ApiContext()
        {
            //this path code is intended for Docker installation
            //DbPath = @"/db_api/romrepo.api.db";

            DbPath = "romrepo.api.db";

            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Configures the database context to use SQLite
        /// </summary>
        /// <param name="options"><see cref="DbContextOptionsBuilder"/></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
