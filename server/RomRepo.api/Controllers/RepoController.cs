using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace RomRepo.api.Controllers
{
    public class RepoController : Controller
    {
        private ApiContext _context;
        public RepoController(ApiContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
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

        [HttpGet("/dbpath")]
        public ActionResult<string> GetDbPath()
        {
            //temporarily disable until admin security defined
            return StatusCode(501);

            //return _context.DbPath;
        }
    }
}
