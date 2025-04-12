namespace RomRepo.api.Services
{
    /// <summary>
    /// Service for managing API key operations
    /// </summary>
    public interface IApiKeyService
    {
        /// <summary>
        /// Gets the status of an individual API Key
        /// </summary>
        /// <param name="key">Key value</param>
        /// <returns><see cref="ApiKeyStatus"/></returns>
        Task<ApiKeyStatus> GetKeyStatus(string key);
        /// <summary>
        /// Set the status of an individual API Key
        /// </summary>
        /// <param name="key">Key value</param>
        /// <param name="status"><see cref="ApiKeyStatus"/></param>
        Task SetKeyStatus(string key, ApiKeyStatus status);
    }
}
