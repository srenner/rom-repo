using Microsoft.AspNetCore.Mvc;
using RomRepo.api.Models;
using RomRepo.api.Services;
using RomRepo.api.DataAccess;

namespace RomRepo.api.Controllers
{
    /// <summary>
    /// Handles operations for game systems
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GameSystemController : ControllerBase
    {
        private readonly IFileService _fileService;
        private IApiRepository _repo;

        /// <summary>Constructor</summary>
        public GameSystemController(IFileService fileService, IApiRepository repo) 
        { 
            _fileService = fileService;
            _repo = repo;
        }

        /// <summary>
        /// Get game system info by ID
        /// </summary>
        /// <param name="id">ID in RomRepo database</param>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<GameSystem>> Get(int id)
        {
            var gs = await _repo.GetGameSystem(id);
            return Ok(gs);
        }

        /// <summary>
        /// Get all game systems
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameSystem>>> GetAll()
        {
            var gss = await _repo.GetGameSystems();
            return Ok(gss);
        }
    }
}
