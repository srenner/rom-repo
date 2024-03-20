using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace RomRepo.api.Controllers
{
    public class RepoController : Controller
    {
        [HttpGet("/version")]
        public string GetVersion()
        {
            try
            {
                return GetType().Assembly.GetName().Version.ToString();
            }
            catch
            {
                return "unknown";
            }
        }
    }
}
