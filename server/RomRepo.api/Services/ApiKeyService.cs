using Microsoft.EntityFrameworkCore;
using RomRepo.api.DataAccess;

namespace RomRepo.api.Services
{
    /// <inheritdoc/>
    public class ApiKeyService : IApiKeyService
    {
        private readonly IApiRepository _repo;
        public ApiKeyService(IApiRepository repo) 
        {
            _repo = repo;
        }

        /// <inheritdoc/>
        public async Task<ApiKeyStatus> GetKeyStatus(string key)
        {
            int keyStatus = await _repo.GetKeyStatus(key);

            return (ApiKeyStatus)keyStatus;
        }

        /// <inheritdoc/>
        public async Task SetKeyStatus(string key, ApiKeyStatus status)
        {
            await _repo.SetKeyStatus(key, status);
        }
    }
}
