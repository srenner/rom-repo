using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RomRepo.console.DataAccess;
using System.Runtime;
using ZstdSharp.Unsafe;

namespace RomRepo.console.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private ILogger<AppController> _logger;
        private IClientRepo _repo;

        public AppController(ILogger<AppController> logger, IClientRepo repo)
        {
            _logger = logger;
            _repo = repo;
            
        }

        [HttpGet("status")]
        public string GetStatus()
        {
            return "ok";
        }

        [HttpGet("version")]
        public string GetVersion()
        {
            return "0.0.1";
        }

        [HttpGet("uniqueID")]
        public async Task<string> GetUniqueID()
        {
            var settings = await _repo.GetSystemSettings();
            var settingUniqueID = settings.Where(w => w.Name == SystemSettingEnum.UniqueIdentifier.Value).FirstOrDefault();
            if (settingUniqueID == null)
            {
                string uniqueID = Guid.NewGuid().ToString();
                await _repo.SaveSystemSetting(SystemSettingEnum.UniqueIdentifier, uniqueID);
                return uniqueID;
            }
            else
            {
                return settingUniqueID.Value;
            }
        }
    }
}
