using RomRepo.api.Models;

namespace RomRepo.api.DataAccess
{
    public interface IApiRepository
    {
        Task<ApiKey> SaveKey(ApiKey apiKey);
        Task<IEnumerable<ApiKey>> GetKeyByEmail(string emailAddress);
        Task<int> GetKeyStatus(string key);
        Task<bool> AddGameSystemWithGames(GameSystem gameSystem);
        Task<GameSystem> GetGameSystem(int id);
        Task<IEnumerable<Rom>> GetRomsByChecksum(ChecksumType checksumType, string val);
        Task<IEnumerable<Rom>> GetRomsByChecksum(string checksum);
    }
}
