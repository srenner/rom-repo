using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using RomRepo.api.DataAccess;
using RomRepo.api.Services;
using System.IO.Compression;

namespace RomRepo.api.Controllers
{
    /// <summary>
    /// Handles operations for import files
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        private IApiRepository _repo;

        /// <summary>Constructor</summary>
        public FileController(IFileService fileService, IApiRepository repo)
        {
            _fileService = fileService;
            _repo = repo;
        }

        /// <summary>
        /// Allows sysadmin to upload new data files
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, CancellationToken cancellationToken)
        {
            var request = HttpContext.Request;
            if (!request.HasFormContentType ||
                !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
                string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
            {
                return new UnsupportedMediaTypeResult();
            }
            else
            {
                if(file.FileName.ToLower().EndsWith(".dat"))
                {
                    var gameSystem = await _fileService.ExtractGameSystem(file.OpenReadStream(), cancellationToken);
                    await _repo.AddGameSystemWithGames(gameSystem);
                    return Ok("Added " + gameSystem.Name + " and " + gameSystem.Games.Count() + " games");
                }
                else if(file.FileName.ToLower().EndsWith(".zip"))
                {

                    using (var archive = new ZipArchive(file.OpenReadStream()))
                    {
                        int systemCount = 0;
                        int gameCount = 0;
                        foreach(var entry in archive.Entries.Where(w => w.Name.EndsWith(".dat")))
                        {
                            var gameSystem = await _fileService.ExtractGameSystem(entry.Open(), cancellationToken);
                            await _repo.AddGameSystemWithGames(gameSystem);
                            systemCount++;
                            gameCount = gameCount + gameSystem.Games.Count();
                        }
                        return Ok("Added " + systemCount + " systems and " + gameCount + " games");
                    }
                }
                return new UnsupportedMediaTypeResult();
            }
        }
    }
}
