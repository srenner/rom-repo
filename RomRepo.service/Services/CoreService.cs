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
        private IClientRepo _repo;

        public CoreService(ILogger<CoreService> logger, IClientRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<IEnumerable<Core>> GetActiveCores()
        {
            return (await _repo.GetAllCores());
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
                        IsActive = false,
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

        public async Task<int> AddCores(List<Core> cores)
        {
            return await _repo.AddCores(cores);
        }

        public async Task UpdateCore(Core core)
        {
            await _repo.UpdateCore(core);
        }
    }
}
