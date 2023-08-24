using Microsoft.AspNetCore.Mvc;
using RomRepo.web.Server.Services;
using System.Runtime.CompilerServices;

namespace RomRepo.web.Server.Controllers
{
    public class CoreAliasController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coreName">Folder name of core on user system</param>
        /// <returns></returns>
        [HttpGet("api/corealias/search/coreName")]
        public async Task<string> CoreAliasSearch(string coreName)
        {
            return await CoreAliasService.Search(coreName);
        }
    }
}
