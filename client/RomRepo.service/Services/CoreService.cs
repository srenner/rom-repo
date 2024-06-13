using Microsoft.Extensions.Logging;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using RomRepo.service.Services.Interfaces;
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
        private IAppService _appService;

        public CoreService(ILogger<CoreService> logger, IClientRepo repo, IAppService appService)
        {
            _logger = logger;
            _repo = repo;
            _appService = appService;
        }

        public async Task<IEnumerable<Core>> GetAllCores()
        {
            return await _repo.GetActiveCores();
        }

        public async Task<IEnumerable<Core>> GetActiveCores()
        {
            return await _repo.GetActiveCores();
        }

        public async Task<IEnumerable<Core>> GetInactiveCores()
        {
            return await _repo.GetInactiveCores();
        }

        public async Task<IEnumerable<DirectoryInfo>> DiscoverCores()
        {
            var newFolders = new List<DirectoryInfo>();
            var cores = await _repo.GetAllCores();

            var rootFolder = await _appService.GetSystemSettingValue(SystemSettingEnum.RomRootFolder);
            if(rootFolder?.Length > 0)
            {
                DirectoryInfo dir = new DirectoryInfo(rootFolder);
                if (dir.Exists)
                {
                    foreach (var coreDir in dir.EnumerateDirectories())
                    {
                        if (!cores.Any(n => n.Name == coreDir.Name))
                        {
                            newFolders.Add(coreDir);
                        }
                    }
                }
                else
                {
                    _logger.LogWarning("Cannot access " + rootFolder);
                }
            }
            else
            {
                _logger.LogError("RomRootFolder not set.");
            }

            return newFolders;
        }

        public List<Core> GetFileSystemCores()
        {
            var cores = new List<Core>();
            DirectoryInfo dir = new DirectoryInfo("ROOT FOLDER");
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
                _logger.LogWarning("Cannot access " + "ROOT FOLDER");
            }
            return cores;
        }

        public async Task<Core> AddCore(Core core)
        {
            var cores = new List<Core>
            {
                core
            };
            await _repo.AddCores(cores);
            return core;
        }

        public async Task<int> AddCores(List<Core> cores)
        {
            return await _repo.AddCores(cores);
        }

        public async Task<bool> UpdateCore(Core core)
        {
            await _repo.UpdateCore(core);
            return true;
        }

    }
}
