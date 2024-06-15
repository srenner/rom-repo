using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.service.Services.Interfaces;
using RomRepo.console.Models;

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
        public string ExtractRom(int romID)
        {
            //_service.
            throw new NotImplementedException();
        }

        [HttpPost("compress")]
        public string CompressRom(string filePath) 
        { 
            throw new NotImplementedException(); 
        }
    }
}
