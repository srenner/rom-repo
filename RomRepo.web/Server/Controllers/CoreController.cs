using Microsoft.AspNetCore.Mvc;

namespace RomRepo.web.Server.Controllers
{
    public class CoreController : Controller
    {





        public IActionResult Index()
        {
            return View();
        }
    }
}
