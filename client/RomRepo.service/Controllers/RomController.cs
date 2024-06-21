using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.service.Services.Interfaces;
using RomRepo.console.Models;
using System.IO.Compression;
using System.Net;
using System.Net.Mime;
using System.IO;
using System;
using System.Runtime.CompilerServices;
using RomRepo.service.Services;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Builder;

namespace RomRepo.console.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RomController : ControllerBase
    {
        private ILogger<RomController> _logger;
        private readonly IRomService _service;

        public RomController(ILogger<RomController> logger, IRomService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Rom>> GetRom(int romID)
        {
            var rom = await _service.GetRom(romID);
            return Ok(rom);
        }

        [HttpGet("discover")]
        public async Task<ActionResult<IEnumerable<Rom>>> DiscoverCoreRomsAsync(int coreID, string path)
        {
            Core core = new Core { Path = path, CoreID = coreID };
            var roms = await _service.DiscoverRoms(core);
            return Ok(roms);
        }

        [HttpGet("crc32")]
        public async Task<ActionResult<string>> GetCRCChecksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            if(rom.IsArchive())
            {
                var files = rom.Extract(isTemporary: true);
                if(files?.Count() > 0)
                {
                    return ChecksumService.CalculateCRC(files[0]);
                }
                else
                {
                    return BadRequest("Archive is empty");
                }
            }
            else
            {
                return ChecksumService.CalculateCRC(rom.Path);
            }
        }

        [HttpGet("md5")]
        public async Task<ActionResult<string>> GetMD5Checksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            if (rom.IsArchive())
            {
                var files = rom.Extract(isTemporary: true);
                if (files?.Count() > 0)
                {
                    return ChecksumService.CalculateHashString<MD5>(MD5.Create(), files[0]);
                }
                else
                {
                    return BadRequest("Archive is empty");
                }
            }
            else
            {
                return ChecksumService.CalculateHashString<MD5>(MD5.Create(), rom.Path);
            }
        }

        [HttpGet("sha1")]
        public async Task<ActionResult<string>> GetSHA1Checksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            if (rom.IsArchive())
            {
                var files = rom.Extract(isTemporary: true);
                if (files?.Count() > 0)
                {
                    return ChecksumService.CalculateHashString<SHA1>(SHA1.Create(), files[0]);
                }
                else
                {
                    return BadRequest("Archive is empty");
                }
            }
            else
            {
                return ChecksumService.CalculateHashString<SHA1>(SHA1.Create(), rom.Path);
            }
        }

        [HttpGet("sha256")]
        public async Task<ActionResult<string>> GetSHA256Checksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            if (rom.IsArchive())
            {
                var files = rom.Extract(isTemporary: true);
                if (files?.Count() > 0)
                {
                    return ChecksumService.CalculateHashString<SHA256>(SHA256.Create(), files[0]);
                }
                else
                {
                    return BadRequest("Archive is empty");
                }
            }
            else
            {
                return ChecksumService.CalculateHashString<SHA256>(SHA256.Create(), rom.Path);
            }
        }

        [HttpPost("addrange")]
        public async Task<ActionResult<int>> AddRoms(IEnumerable<Rom> roms)
        {
            int result = await _service.AddRoms(roms);
            return Ok(result);
        }


        [HttpPost("extract")]
        public async Task<IActionResult> ExtractRom(int romID, bool isTemporary)
        {
            var rom = await _service.GetRom(romID);
            if(rom.IsArchive())
            {
                var paths = rom.Extract(isTemporary);
                return File(System.IO.File.ReadAllBytes(paths[0]), "application/octet-stream", System.IO.Path.GetFileName(paths[0]));
            }
            else
            {
                throw new IOException("Archive type not recognized: " + rom.Path);
            }
        }

        [HttpPost("compress")]
        public string CompressRom(string filePath) 
        { 
            throw new NotImplementedException(); 
        }
    }
}
