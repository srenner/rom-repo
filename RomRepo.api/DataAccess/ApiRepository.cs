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
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return apiKey;
        }
    }
}
