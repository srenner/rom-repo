﻿using Microsoft.Extensions.Logging;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using RomRepo.service.Services.Interfaces;
using SharpCompress.Archives;
using SharpCompress.Archives.Zip;

namespace RomRepo.console.Services
{
    internal class RomService : IRomService
    {
        private readonly ILogger<RomService> _logger;
        private readonly IClientRepo _repo;

        public RomService(ILogger<RomService> logger, IClientRepo repo) 
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<Rom> GetRom(int romID)
        {
            return await _repo.GetRom(romID);
        }

        public async Task<IEnumerable<Rom>> GetRomsForCore(int coreID)
        {
            return await _repo.GetRomsForCore(coreID);
        }

        public async Task<IEnumerable<Rom>> DiscoverRoms(Core core)
        {
            if (core == null) throw new ArgumentNullException(nameof(core));
            var dbRoms = await _repo.GetRomsForCore(core.CoreID);

            var roms = new List<Rom>();
            DirectoryInfo di = new DirectoryInfo(core.Path);
            if (di.Exists)
            {
                foreach (var file in di.EnumerateFiles("*", SearchOption.AllDirectories))
                {
                    if (!dbRoms.Any(a => a.Path == file.FullName))
                    {
                        var now = DateTime.UtcNow;
                        roms.Add(new Rom
                        {
                            Path = file.FullName,
                            IsActive = false,
                            IsFavorite = false,
                            CoreID = core.CoreID,
                            DateCreated = file.CreationTime,
                            DateUpdated = file.LastWriteTime
                        });
                    }
                }
            }
            return roms;
        }

        public async Task<Rom> AddRom(Rom rom)
        {
            return await _repo.AddRom(rom);
        }

        public async Task<int> AddRoms(IEnumerable<Rom> roms)
        {
            return await _repo.AddRoms(roms);
        }

        public MemoryStream ExtractAndPack(IEnumerable<Rom> roms)
        {
            if(roms == null || roms.Count() == 0)
            {
                throw new ArgumentNullException(nameof(roms));
            }
            MemoryStream ms = new MemoryStream();
            using (var archive = ZipArchive.Create())
            {
                foreach (var rom in roms)
                {
                    var romStream = rom.ExtractToStream();
                    if (romStream.MemoryStream != null)
                    {
                        archive.AddEntry(romStream.Filename, romStream.MemoryStream);
                    }
                }
                archive.SaveTo(ms);
            }
            return ms;
        }

    }
}
