using Microsoft.EntityFrameworkCore;
using RomRepo.api.DataAccess;

namespace RomRepo.api.Services
{
    public class ApiKeyService : IApiKeyService
    {
        private readonly IApiRepository _repo;
        public ApiKeyService(IApiRepository repo) 
        {
            _repo = repo;
        }

        public async Task<ApiKeyStatus> GetKeyStatus(string key)
        {
            int keyStatus = await _repo.GetKeyStatus(key);

            return (ApiKeyStatus)keyStatus;
        }

        public async Task SetKeyStatus(string key, ApiKeyStatus status)
        {
            await _repo.SetKeyStatus(key, status);
        }
    }
}
