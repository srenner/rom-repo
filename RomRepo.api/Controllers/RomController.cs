using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomRepo.api.DataAccess;
using RomRepo.api.Models.NotMapped;
using RomRepo.api.Services;
using System.Runtime.CompilerServices;

namespace RomRepo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RomController : ControllerBase
    {
        private IApiRepository _repo;
        private IRomService _romService;

        public RomController(IApiRepository repo, IRomService romService)
        {
            _repo = repo;
            _romService = romService;
        }


        [HttpGet("checksum")]
        public async Task<IEnumerable<RomInfo>> GetRomsByChecksum(string checksum)
        {
            var roms = await _romService.GetRoms(checksum);
            return roms;
        }

        [HttpGet("checksum/crc/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyByCRC(string checksum)
        {
            var roms = await _repo.GetRomsByChecksum(ChecksumType.CRC, checksum);

            throw new NotImplementedException();
        }

        [HttpGet("checksum/md5/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyByMD5(string checksum)
        {
            throw new NotImplementedException(checksum);
        }

        [HttpGet("checksum/sha1/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyBySHA1(string checksum)
        {
            throw new NotImplementedException(checksum);
        }

        [HttpGet("checksum/sha256/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyBySHA256(string checksum)
        {
            throw new NotImplementedException(checksum);
        }




    }
}
