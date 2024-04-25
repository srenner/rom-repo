﻿using Microsoft.EntityFrameworkCore;
using RomRepo.api.Models;

namespace RomRepo.api
{
    public class ApiContext : DbContext
    {
        public DbSet<ApiKey> ApiKey { get; set; }
        public DbSet<GameSystem> GameSystem { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Rom> Rom { get; set; }
        public DbSet<GameAttribute> GameAttribute { get; set; }
        public DbSet<GameFavorite> GameFavorite { get; set; }
        public DbSet<GameSystemFavorite> GameSystemFavorite { get; set; }
        public DbSet<GameInstallation> GameInstallation { get; set; }

        public string DbPath { get; }

        public ApiContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            //may be different structure for mswindows vs docker
            string subfolder = "\\RomRepo";       //works for MSWindows
            if (!Directory.Exists(path + subfolder))
            {
                Directory.CreateDirectory(path + subfolder);
            }
            DbPath = System.IO.Path.Join(path + subfolder + "\\", "romrepo.api.db");
            //DbPath = System.IO.Path.Join(path + "\\romrepo.api.db");
            this.Database.EnsureCreated();
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
