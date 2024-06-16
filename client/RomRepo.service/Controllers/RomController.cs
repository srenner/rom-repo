using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.service.Services.Interfaces;
using RomRepo.console.Models;
using System.IO.Compression;
using System.Net;
using System.Net.Mime;
using System.IO;

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

        [HttpPost("addrange")]
        public async Task<ActionResult<int>> AddRoms(IEnumerable<Rom> roms)
        {
            int result = await _service.AddRoms(roms);
            return Ok(result);
        }


        [HttpPost("extract")]
        public async Task<ActionResult<List<string>>> ExtractRom(int romID)
        {
            var rom = await _service.GetRom(romID);
            if(rom.Path.EndsWith(".zip"))
            {
                var ret = rom.Extract();
                return ret;
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
