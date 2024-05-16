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
        public DbSet<Rom> Rom { get; set; }
        public DbSet<SystemSetting> SystemSetting { get; set; }

        public string DbPath { get; }

        public RomRepoContext()
        {
            //this path code is intended for Docker installation


            //if docker
            if(Directory.Exists(@"/db_client"))
            {
                DbPath = @"/db_client/romrepo.client.db";
            }
            //else assume windows (may work on linux?)
            else
            {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Environment.GetFolderPath(folder);
                string subfolder = "\\RomRepo";
                if (!Directory.Exists(path + subfolder))
                {
                    Directory.CreateDirectory(path + subfolder);
                }
                DbPath = System.IO.Path.Join(path + subfolder + "\\", "romrepo.client.db");
            }
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(" *** CRITICAL ERROR *** ");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
