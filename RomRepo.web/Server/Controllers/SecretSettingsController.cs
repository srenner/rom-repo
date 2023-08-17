using Microsoft.AspNetCore.Mvc;

namespace RomRepo.web.Server.Controllers
{
    public class SecretSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();


        }

        [HttpGet("/setting/romroot")]
        public bool GetRomRoot()
        {
            throw new NotImplementedException();
        }
    }
}
