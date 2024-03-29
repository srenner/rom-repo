﻿using Microsoft.AspNetCore.Http;
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
        public async Task<IEnumerable<RomInfo>> GetRomsByChecksum(string val)
        {
            var roms = await _romService.GetRoms(val);
            return roms;
        }

        [HttpGet("checksum/crc/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyByCRC(string checksum)
        {
            var roms = await _romService.GetRoms(checksum, ChecksumType.CRC);
            return roms;
        }

        [HttpGet("checksum/md5/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyByMD5(string checksum)
        {
            var roms = await _romService.GetRoms(checksum, ChecksumType.MD5);
            return roms;
        }

        [HttpGet("checksum/sha1/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyBySHA1(string checksum)
        {
            var roms = await _romService.GetRoms(checksum, ChecksumType.SHA1);
            return roms;
        }

        [HttpGet("checksum/sha256/{checksum}")]
        public async Task<IEnumerable<RomInfo>> GetRomyBySHA256(string checksum)
        {
            var roms = await _romService.GetRoms(checksum, ChecksumType.SHA256);
            return roms;
        }




    }
}
