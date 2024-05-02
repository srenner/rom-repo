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
            //this path code is intended for Docker installation
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            //string subfolder = @"/db";
            //if (!Directory.Exists(path + subfolder))
            //{
            //    Directory.CreateDirectory(path + subfolder);
            //}
            DbPath = @"/db/romrepo.api.db";
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
