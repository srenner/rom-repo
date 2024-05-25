namespace RomRepo.api.Services
{
    public interface IApiKeyService
    {
        Task<ApiKeyStatus> GetKeyStatus(string key);
        Task SetKeyStatus(string key, ApiKeyStatus status);
    }
}
