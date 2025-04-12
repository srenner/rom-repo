using Microsoft.AspNetCore.Mvc;
using RomRepo.api.DataAccess;
using RomRepo.api.Models.NotMapped;
using RomRepo.api.Services;

namespace RomRepo.api.Controllers
{
    /// <summary>
    /// Handles operations for individual games
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RomController : ControllerBase
    {
        private IRomService _romService;

        /// <summary>Constructor</summary>
        public RomController(IRomService romService)
        {
            _romService = romService;
        }

        /// <summary>
        /// Get matching rom for a given unknown checksum value, if exists
        /// </summary>
        /// <remarks>This method is slower and less efficient than using the specific checksum types</remarks>
        /// <param name="val"></param>
        /// <returns></returns>
        [HttpGet("checksum")]
        public async Task<IEnumerable<RomInfo>> GetRomsByChecksum(string val)
        {
            var roms = await _romService.GetRoms(val);
            return roms;
        }

        /// <summary>
        /// Get matching rom for a given CRC checksum, if exists
        /// </summary>
        /// <param name="checksum"></param>
        /// <returns></returns>
        [HttpGet("checksum/crc/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyByCRC(string checksum)
        {
            var roms = await _romService.GetRoms(checksum, ChecksumType.CRC);
            return roms;
        }

        /// <summary>
        /// Get matching rom for a given MD5 checksum, if exists
        /// </summary>
        /// <param name="checksum"></param>
        /// <returns></returns>
        [HttpGet("checksum/md5/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyByMD5(string checksum)
        {
            var roms = await _romService.GetRoms(checksum, ChecksumType.MD5);
            return roms;
        }

        /// <summary>
        /// Get matching rom for a given SHA1 checksum, if exists
        /// </summary>
        /// <param name="checksum"></param>
        /// <returns></returns>
        [HttpGet("checksum/sha1/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyBySHA1(string checksum)
        {
            var roms = await _romService.GetRoms(checksum, ChecksumType.SHA1);
            return roms;
        }

        /// <summary>
        /// Get matching rom for a given SHA256 checksum, if exists
        /// </summary>
        /// <param name="checksum"></param>
        /// <returns></returns>
        [HttpGet("checksum/sha256/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyBySHA256(string checksum)
        {
            var roms = await _romService.GetRoms(checksum, ChecksumType.SHA256);
            return roms;
        }
    }
}
