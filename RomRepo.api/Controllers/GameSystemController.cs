using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RomRepo.api.Models;
using RomRepo.api.Services;


using Microsoft.Net.Http.Headers;
using RomRepo.api.DataAccess;


namespace RomRepo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameSystemController : ControllerBase
    {
        private readonly IFileService _fileService;
        private IApiRepository _repo;

        public GameSystemController(IFileService fileService, IApiRepository repo) 
        { 
            _fileService = fileService;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<GameSystem>> Get(int id)
        {
            var gs = await _repo.GetGameSystem(id);
            return Ok(gs);
        }
    }
}
