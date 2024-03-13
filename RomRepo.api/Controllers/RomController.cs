using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomRepo.api.DataAccess;
using RomRepo.api.Models.NotMapped;
using RomRepo.api.Services;

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


    }
}
