using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.console.Controllers;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using RomRepo.console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSettingController : ControllerBase
    {
        private ILogger<SystemSettingController> _logger;
        private readonly IClientRepo _repo;

        public SystemSettingController(ILogger<SystemSettingController> logger, IClientRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }


        [HttpGet("{name}")]
        public async Task<SystemSetting> GetSystemSetting(string name)
        {
            //_repo.GetSystemSetting()
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IEnumerable<SystemSetting>> GetSystemSettings()
        {

            return await _repo.GetSystemSettings();
        }

    }
}
