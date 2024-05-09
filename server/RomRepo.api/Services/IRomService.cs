using RomRepo.api.Models.NotMapped;

namespace RomRepo.api.Services
{
    public interface IRomService
    {
        Task<IEnumerable<RomInfo>> GetRoms(string checksum, ChecksumType? ct = null);
    }
}
