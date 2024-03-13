using Microsoft.EntityFrameworkCore;
using RomRepo.api.Models;

namespace RomRepo.api.DataAccess
{
    public class ApiRepository : IApiRepository
    {
        private ApiContext _context;
        private ILogger<ApiRepository> _logger;
        public ApiRepository(ApiContext context, ILogger<ApiRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

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

        public async Task<GameSystem> GetGameSystem(int id)
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

    }
}
