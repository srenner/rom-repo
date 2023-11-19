using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.console.Models;
using RomRepo.console.Services;
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
        public List<Core> DiscoverCoresAsync()
        {
            var cores = _service.GetFileSystemCores("rootFolder");
            return cores;
        }

        [HttpGet("{id}")]
        public async Task <Core?> GetCore(int id)
        {
            return (await GetActiveCoresAsync()).FirstOrDefault(x => x.CoreID == id);
        }

        [HttpPost]
        public async Task<bool> SaveCore([FromBody]Core core)
        {
            
            //_service.
            throw new NotImplementedException();
        }

    }
}
