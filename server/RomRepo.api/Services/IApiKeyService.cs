namespace RomRepo.api.Services
{
    public interface IApiKeyService
    {
        Task<ApiKeyStatus> GetKeyStatus(string key);
    }
}
