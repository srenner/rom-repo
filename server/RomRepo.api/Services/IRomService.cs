using RomRepo.api.Models.NotMapped;

namespace RomRepo.api.Services
{
    /// <summary>
    /// Service for handling ROM related operations
    /// </summary>
    public interface IRomService
    {
        /// <summary>
        /// Get matching rom for a given checksum value, if exists
        /// </summary>
        /// <param name="checksum">Checksum value</param>
        /// <param name="ct"><see cref="ChecksumType"/></param>
        /// <returns></returns>
        Task<IEnumerable<RomInfo>> GetRoms(string checksum, ChecksumType? ct = null);
    }
}
