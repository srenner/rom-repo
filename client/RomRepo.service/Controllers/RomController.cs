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
            //680;
            var rom = await _service.GetRom(romID);
            string path = "/app-cache/61/680/Super Off Road (USA).sfc";
            return ChecksumService.CalculateCRC(path);
        }

        [HttpGet("md5")]
        public async Task<ActionResult<string>> GetMD5Checksum(int romID)
        {
            var rom = await _service.GetRom(romID);
            string path = "/app-cache/61/680/Super Off Road (USA).sfc";
            //path = "/app-userfiles/games/SNES/Super Off Road (USA).zip";
            return ChecksumService.CalculateMD5(path);
        }

        [HttpPost("addrange")]
        public async Task<ActionResult<int>> AddRoms(IEnumerable<Rom> roms)
        {
            int result = await _service.AddRoms(roms);
            return Ok(result);
        }


        [HttpPost("extract")]
        public async Task<IActionResult> ExtractRom(int romID)
        {
            var rom = await _service.GetRom(romID);
            if(rom.Path.EndsWith(".zip"))
            {
                var paths = rom.Extract();
                return File(System.IO.File.ReadAllBytes(paths[0]), "application/octet-stream", System.IO.Path.GetFileName(paths[0]));
            }
            else
            {
                throw new NotImplementedException("Only .zip is currently supported");
            }
            throw new NotImplementedException("oops");
        }

        [HttpPost("compress")]
        public string CompressRom(string filePath) 
        { 
            throw new NotImplementedException(); 
        }
    }
}
