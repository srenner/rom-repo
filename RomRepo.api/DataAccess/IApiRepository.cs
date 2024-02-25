using RomRepo.api.Models;

namespace RomRepo.api.DataAccess
{
    public interface IApiRepository
    {
        Task<ApiKey> SaveKey(ApiKey apiKey);
        Task<IEnumerable<ApiKey>> GetKeyByEmail(string emailAddress);
    }
}
