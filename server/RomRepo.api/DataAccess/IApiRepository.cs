using RomRepo.api.Models;

namespace RomRepo.api.DataAccess
{
    /// <summary>
    /// Repository for API data access
    /// </summary>
    public interface IApiRepository
    {
        #region Key Management

        /// <summary>Gets list of API keys by email address</summary>
        Task<IEnumerable<ApiKey>> GetKeyByEmail(string emailAddress);

        /// <summary>Get status of an individual API Key</summary>
        Task<int> GetKeyStatus(string key);

        /// <summary>Set the status of an individual API Key</summary>
        Task SetKeyStatus(string key, ApiKeyStatus status);

        /// <summary>Adds a new API key to the database</summary>
        Task<ApiKey> SaveKey(ApiKey apiKey);

        #endregion

        #region Game System and Games

        /// <summary>Adds a new GameSystem with associated games</summary>
        Task<bool> AddGameSystemWithGames(GameSystem gameSystem);
        
        /// <summary>Gets an individual Game System by internal ID</summary>
        Task<GameSystem?> GetGameSystem(int id);

        /// <summary>Gets a list of all Game Systems</summary>
        Task<IEnumerable<GameSystem>> GetGameSystems();

        /// <summary>Updates an existing Game System</summary>
        Task<GameSystem> UpdateGameSystem(GameSystem gameSystem);

        #endregion

        #region Roms

        /// <summary>Gets a list of Roms by specified checksum type and value</summary>
        Task<IEnumerable<Rom>> GetRomsByChecksum(ChecksumType checksumType, string val);

        /// <summary>Gets a list of Roms by checksum value withou specifying checksum type</summary>
        Task<IEnumerable<Rom>> GetRomsByChecksum(string checksum);

        #endregion
    }
}
