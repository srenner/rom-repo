using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RomRepo.console.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {

        [HttpGet("version")]
        public string GetVersion()
        {
            return "0.0.1";
        }
    }
}
