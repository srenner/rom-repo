﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.console.DataAccess;
using RomRepo.service.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using ZstdSharp.Unsafe;

namespace RomRepo.console.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private ILogger<AppController> _logger;
        private IAppService _service;

        public AppController(ILogger<AppController> logger, IAppService service)
        {
            _logger = logger;
            _service = service;
            
        }

        [HttpGet("status")]
        public ActionResult<string> GetStatus()
        {
            return Ok("ok");
        }

        [HttpGet("version")]
        public ActionResult<string> GetVersion()
        {
            return Ok("0.0.1");
        }
    }
}
