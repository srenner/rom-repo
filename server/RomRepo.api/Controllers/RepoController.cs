using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RomRepo.api.Controllers
{
    /// <summary>
    /// Handles operations for API information
    /// </summary>
    public class RepoController : Controller
    {
        // <summary>Constructor</summary>
        public RepoController()
        {
        }

        /// <summary>
        /// Get the current version of the API
        /// </summary>
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

        /// <summary>
        /// Debug info for sysadmin
        /// </summary>
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("/dbpath")]
        public ActionResult<string> GetDbPath()
        {
            //temporarily disable until admin security defined
            return StatusCode(501);
            //return _context.DbPath;
        }
    }
}
