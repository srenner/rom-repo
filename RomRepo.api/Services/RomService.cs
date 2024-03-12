using Microsoft.AspNetCore.Mvc.TagHelpers;
using RomRepo.api.DataAccess;
using RomRepo.api.Models;
using RomRepo.api.Models.NotMapped;

namespace RomRepo.api.Services
{
    public class RomService : IRomService
    {
        private readonly IApiRepository _repo;
        public RomService(IApiRepository repo) 
        {
            _repo = repo;
        }

        public async Task<IEnumerable<RomInfo>> GetRoms(string checksum)
        {
            var roms = await _repo.GetRomsByChecksum(checksum);
            var romsList = new List<RomInfo>();

            foreach(var rom in roms)
            {
                romsList.Add(new RomInfo
                { 
                    Authors = rom.Game.GameSystem.Author,
                    CRC = rom.CRC,
                    GameName = rom.Game.Name,
                    GameSystemName = rom.Game.GameSystem.Name,
                    MD5 = rom.MD5,
                    RomName = rom.Name,
                    SHA1 = rom.SHA1,
                    SHA256 = rom.SHA256,
                    Size = rom.Size,
                    Status = rom.Status
                });
            }


            return romsList;
        }


    }
}
