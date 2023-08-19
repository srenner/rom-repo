using Microsoft.AspNetCore.Mvc;

namespace RomRepo.web.Server.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();


        }

        [HttpGet("api/setting/romroot")]
        public string GetRomRoot()
        {
            //todo get from settings file
            return "\\\\mister\\sdcard\\games";
            throw new NotImplementedException();
        }

        [HttpGet("api/setting/saveroot")]
        public bool GetSaveRoot()
        { 
            throw new NotImplementedException(); 
        }

        [HttpGet("api/setting/savestateroot")]
        public bool GetSaveStateRoot()
        {
            throw new NotImplementedException();
        }
    }
}
