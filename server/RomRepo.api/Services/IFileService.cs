using RomRepo.api.Models;

namespace RomRepo.api.Services
{
    /// <summary>
    /// Service for handling file operations related to DAT files
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Extracts a GameSystem from a DAT file stream
        /// </summary>
        /// <param name="stream">DAT file for an individual game system</param>
        /// <param name="cancellationToken">Listens for RequestAborted signal</param>
        /// <returns></returns>
        Task<GameSystem?> ExtractGameSystem(Stream stream, CancellationToken cancellationToken);
    }
}
