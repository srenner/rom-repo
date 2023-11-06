using Microsoft.Extensions.Logging;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Services
{
    public class CoreService : ICoreService
    {
        private ILogger<CoreService> _logger;
        private IRepoRepo _repo;

        public CoreService(ILogger<CoreService> logger, IRepoRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public List<Core> GetFileSystemCores(string rootFolder)
        {
            if(rootFolder == null) throw new ArgumentNullException(nameof(rootFolder));

            var cores = new List<Core>();
            DirectoryInfo dir = new DirectoryInfo(rootFolder);
            if (dir.Exists)
            {
                foreach (var coreDir in dir.EnumerateDirectories())
                {
                    var now = DateTime.UtcNow;
                    cores.Add(new Core
                    {
                        Name = coreDir.Name,
                        Path = coreDir.FullName,
                        Description = "",
                        FileExtensions = "",
                        ZipAsRom = false,
                        SevenZipAsRom = false,
                        IsActive = true,
                        IsFavorite = false,
                        DateCreated = now,
                        DateUpdated = now
                    });
                }
            }
            else
            {
                _logger.LogWarning("Cannot access " + rootFolder);
            }
            return cores;
        }


        public async Task<int> FindAndAddCores(string rootFolder)
        {
            var cores = GetFileSystemCores(rootFolder);
            return await _repo.AddCores(cores);
        }
    }
}
