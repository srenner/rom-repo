using Microsoft.EntityFrameworkCore;
using RomRepo.api.Models;

namespace RomRepo.api.DataAccess
{
    /// <inheritdoc/>
    public class ApiRepository : IApiRepository
    {
        private ApiContext _context;
        private ILogger<ApiRepository> _logger;

        /// <summary>Constructor</summary>
        public ApiRepository(ApiContext context, ILogger<ApiRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region Key Management

        /// <inheritdoc/>
        public async Task<IEnumerable<ApiKey>> GetKeyByEmail(string emailAddress)
        {
            try
            {
                //return await _context.ApiKey.Where(w => w.Email.Equals(emailAddress, StringComparison.CurrentCultureIgnoreCase)).ToListAsync();
                return await _context.ApiKey.Where(w => w.Email == emailAddress).ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in ApiRepository.GetKey(emailAddress: {emailAddress})", emailAddress, ex);
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<int> GetKeyStatus(string key)
        {
            try
            {
                var apiKey = await _context.ApiKey.Where(w => w.Key == key).FirstOrDefaultAsync();
                return apiKey != null ? apiKey.Status : (int)ApiKeyStatus.Unknown;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return (int)ApiKeyStatus.Unknown;
            }
        }

        /// <inheritdoc/>
        public async Task SetKeyStatus(string key, ApiKeyStatus status)
        {
            int newStatusID = (int)status;
            try
            {
                var keyEntity = await _context.ApiKey.Where(w => w.Key == key).FirstOrDefaultAsync();
                if (keyEntity != null)
                {
                    keyEntity.Status = newStatusID;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc/>
        public async Task<ApiKey> SaveKey(ApiKey apiKey)
        {
            try
            {
                await _context.AddAsync(apiKey);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return apiKey;
        }

        #endregion

        #region Game System and Games

        /// <inheritdoc/>
        public async Task<bool> AddGameSystemWithGames(GameSystem gameSystem)
        {
            try
            {
                await _context.AddAsync(gameSystem);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var name = gameSystem.Name;
                _logger.LogError($"Error in ApiRepository.AddGameSystemWithGames(gameSystem: {name})", name, ex);
                return false;
            }
        }

        /// <inheritdoc/>
        public async Task<GameSystem?> GetGameSystem(int id)
        {
            try
            {
                return await _context.GameSystem.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in ApiRepository.GetGameSystem(id: {id})", id, ex);
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<GameSystem>> GetGameSystems()
        {
            try
            {
                return await _context.GameSystem.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ApiRepository.GetGameSystems()", ex);
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<GameSystem> UpdateGameSystem(GameSystem gameSystem)
        {
            try
            {
                _context.GameSystem.Update(gameSystem);
                await _context.SaveChangesAsync();
                return gameSystem;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in ApiRepository.UpdateGameSystem(gameSystem: {gameSystem.Name})", gameSystem.Name, ex);
                return null;
            }
        }

        #endregion

        #region Roms

        /// <inheritdoc/>
        public async Task<IEnumerable<Rom>> GetRomsByChecksum(ChecksumType checksumType, string val)
        {
            try
            {
                var roms = _context.Rom.AsQueryable();

                //TODO room for improvement
                switch (checksumType)
                {
                    case ChecksumType.CRC:
                        roms = roms.Where(w => w.CRC == val);
                        break;
                    case ChecksumType.MD5:
                        roms = roms.Where(w => w.MD5 == val);
                        break;
                    case ChecksumType.SHA1:
                        roms = roms.Where(w => w.SHA1 == val);
                        break;
                    case ChecksumType.SHA256:
                        roms = roms.Where(w => w.SHA256 == val);
                        break;
                }
                return await roms.Include(i => i.Game.GameSystem).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("oops");
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Rom>> GetRomsByChecksum(string checksum)
        {
            try
            {
                var roms = await _context.Rom
                    .Include(i => i.Game.GameSystem)
                    .Where(w => w.CRC == checksum || w.MD5 == checksum || w.SHA1 == checksum || w.SHA256 == checksum)
                    .ToListAsync();
                return roms;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in ApiRepository.GetRomsByChecksum(checksum: {checksum})", checksum, ex);
                return null;
            }
        }

        #endregion
    }
}
