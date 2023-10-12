using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console
{
    public class RomRepoContext : DbContext
    {
        public DbSet<Core> Core { get; set; }
        public DbSet<SystemSetting> SystemSetting { get; set; }

        public string DbPath { get; }

        public RomRepoContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            string subfolder = "\\RomRepo";
            
            if(!Directory.Exists(path + subfolder))
            {
                Directory.CreateDirectory(path + subfolder);
            }
            
            DbPath = System.IO.Path.Join(path + subfolder + "\\", "romrepo.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
