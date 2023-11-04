using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace RomRepo.api.Controllers
{
    public class RepoController : Controller
    {







        [HttpGet("/version")]
        public string GetVersion()
        {
            throw new NotImplementedException();
        }
    }
}
