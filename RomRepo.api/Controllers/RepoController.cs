using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace RomRepo.api.dat.Controllers
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
