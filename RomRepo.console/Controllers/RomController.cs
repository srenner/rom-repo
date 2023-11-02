using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.console.DataAccess;
using RomRepo.console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [HttpPost("extract")]
        public bool ExtractRom(string filePath)
        {
            bool success = _service.ExtractRom(filePath);
            return false;
        }
    }
}
