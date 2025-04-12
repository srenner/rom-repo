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

        public async Task<IEnumerable<RomInfo>> GetRoms(string checksum, ChecksumType? ct = null)
        {
            IEnumerable<Rom> roms;
            if(ct == null)
            {
                roms = await _repo.GetRomsByChecksum(checksum);
            }
            else
            {
                roms = await _repo.GetRomsByChecksum(ct.Value, checksum);
            }
            var romsList = new List<RomInfo>();
            foreach(var rom in roms)
            {
                romsList.Add(new RomInfo
                { 
                    Authors = rom.Game.GameSystem.Author.Split(',').Select(a => a.Trim()).ToArray(),
                    CRC = rom.CRC,
                    GameName = rom.Game.Name,
                    GameSystemName = rom.Game.GameSystem.Name,
                    MD5 = rom.MD5,
                    RomName = rom.Name,
                    SHA1 = rom.SHA1,
                    SHA256 = rom.SHA256,
                    Serial = rom.Serial,
                    Size = rom.Size,
                    Status = rom.Status
                });
            }
            return romsList;
        }
    }
}
