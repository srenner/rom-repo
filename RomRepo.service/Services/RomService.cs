using Microsoft.Extensions.Logging;
using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.Services
{
    internal class RomService : IRomService
    {
        private readonly ILogger<RomService> _logger;
        public RomService(ILogger<RomService> logger) 
        {
            _logger = logger;
        }

        public List<Rom> GetFileSystemRoms(Core core)
        {
            if (core == null) throw new ArgumentNullException(nameof(core));

            var roms = new List<Rom>();
            DirectoryInfo dir = new DirectoryInfo(core.Path);
            if (dir.Exists)
            {
                foreach (var romDir in dir.EnumerateDirectories())
                {
                    var now = DateTime.UtcNow;
                    roms.Add(new Rom
                    {
                        Path = romDir.FullName,
                        IsActive = false,
                        IsFavorite = false,
                        CoreID = core.CoreID,
                        DateCreated = now,
                        DateUpdated = now
                    });
                }
            }
            else
            {
                _logger.LogWarning("Cannot access " + core.Path);
            }
            return roms;
        }

    }
}
