using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.DataAccess
{
    public class RepoRepo : IRepoRepo
    {
        private readonly RomRepoContext _context;
        private readonly ILogger<RepoRepo> _logger;

        public RepoRepo(RomRepoContext context, ILogger<RomRepo.console.DataAccess.RepoRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<SystemSetting> SaveSystemSetting(SystemSettingEnum setting, string settingValue)
        {
            try
            {
                using var transaction = _context.Database.BeginTransaction();
                int rows = await _context.Database.ExecuteSqlAsync($"REPLACE INTO SystemSetting(Name, Value) VALUES ({setting.Value}, {settingValue});");
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                if(rows == 1)
                {
                    return new SystemSetting { Name = setting.Value, Value = settingValue };
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return new SystemSetting(); // empty if failed to return above
        }


        public async Task<IEnumerable<SystemSetting>> SaveSystemSettings(IEnumerable<SystemSetting> settings)
        {
            try
            {
                _context.Add(settings);
                await _context.SaveChangesAsync();
                return settings;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<string?> GetSystemSetting(SystemSettingEnum setting)
        {
            try
            {
                return await _context.Database.SqlQuery<string>($"SELECT Value FROM SystemSetting where Name = {setting.Value}").FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<IEnumerable<SystemSetting>> GetSystemSettings()
        {
            try
            {
                return await _context.SystemSetting.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public IEnumerable<Core> GetAllCores()
        {
            return _context.Core.Where(w => w.IsActive == true).ToList();
        }

        public async Task<int> AddCores(IEnumerable<Core> cores)
        {
            try
            {
                _context.Core.AddRange(cores);
                return await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return -1;
            }
            
        }

        public void GetCore(int coreID)
        {
            throw new NotImplementedException();
        }

        public void GetRom(int romID)
        {
            throw new NotImplementedException();
        }

        public void GetRomsForCore(int coreID)
        {
            throw new NotImplementedException();
        }

        public void UpdateCore(int coreID)
        {
            throw new NotImplementedException();
        }

        public void UpdateRom(int romID)
        {
            throw new NotImplementedException();
        }

    }
}
