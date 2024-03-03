using RomRepo.api.Models;

namespace RomRepo.api.Services
{
    public interface IFileService
    {
        Task<GameSystem> ExtractGameSystem(IFormFile file);
    }
}
