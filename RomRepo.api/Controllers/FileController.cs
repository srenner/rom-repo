using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using RomRepo.api.DataAccess;
using RomRepo.api.Services;
using System.Web.Http.Results;

namespace RomRepo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IFileService _fileService;
        private IApiRepository _repo;

        public FileController(IFileService fileService, IApiRepository repo)
        {
            _fileService = fileService;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {

            var request = HttpContext.Request;

            // validation of Content-Type
            // 1. first, it must be a form-data request
            // 2. a boundary should be found in the Content-Type
            if (!request.HasFormContentType ||
                !MediaTypeHeaderValue.TryParse(request.ContentType, out var mediaTypeHeader) ||
                string.IsNullOrEmpty(mediaTypeHeader.Boundary.Value))
            {
                return new UnsupportedMediaTypeResult();
            }
            else
            {
                var gameSystem = await _fileService.ExtractGameSystem(file);
                await _repo.AddGameSystemWithGames(gameSystem);

                return Ok("Added " + gameSystem.Name  +" and " + gameSystem.Games.Count() + " games");
            }
        }
    }
}
