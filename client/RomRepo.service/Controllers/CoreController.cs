using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.console.Models;
using RomRepo.service;
using RomRepo.service.Services.Interfaces;
using RomRepo.service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace RomRepo.console.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        private ILogger<CoreController> _logger;
        private readonly ICoreService _service;

        public CoreController(ILogger<CoreController> logger, ICoreService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("active")]
        public async Task<List<Core>> GetActiveCoresAsync()
        {
            var cores = await _service.GetActiveCores();
            return cores.ToList();
        }

        [HttpGet("discover")]
        public async Task<ActionResult<IEnumerable<DirectoryInfoViewModel>>> DiscoverCoresAsync()
        {
            var folders = await _service.DiscoverCores();

            _logger.LogInformation(folders.Count() + " new core folders discovered and added to database.");

            return Ok(folders.ToViewModel());
        }

        [HttpGet("{id}")]
        public async Task <Core?> GetCore(int id)
        {
            return (await GetActiveCoresAsync()).FirstOrDefault(x => x.CoreID == id);
        }

        [HttpPost]
        public async Task<bool> SaveCore([FromBody]Core core)
        {
            if(core.CoreID > 0)
            {
                return await _service.UpdateCore(core);
            }
            else
            {
                await _service.AddCore(core);
                return true;
            }
        }

    }
}
