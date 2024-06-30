using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RomRepo.console.Models;
using RomRepo.service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace RomRepo.console.DataAccess
{
    public class ClientRepo : IClientRepo
    {
        private readonly RomRepoContext _context;
        private readonly ILogger<ClientRepo> _logger;

        public ClientRepo(RomRepoContext context, ILogger<ClientRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region ===== Core ================================

        public async Task<Core?> GetCore(int coreID)
        {
            return await _context.Core.FindAsync(coreID);
        }

        public async Task<IEnumerable<Core>> GetAllCores()
        {
            return await _context.Core.ToListAsync();
        }

        public async Task<IEnumerable<Core>> GetActiveCores()
        {
            return await _context.Core.Where(w => w.IsActive == true).ToListAsync();
        }

        public async Task<IEnumerable<Core>> GetInactiveCores()
        {
            return await _context.Core.Where(w => w.IsActive == false).ToListAsync();
        }

        public async Task<int> AddCores(IEnumerable<Core> cores)
        {
            try
            {
                _context.Core.AddRange(cores);
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return -1;
            }
        }

        public async Task<bool> UpdateCore(Core core)
        {
            try
            {
                _context.Update(core);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        #endregion

        #region ===== Rom =================================

        public async Task<Rom> GetRom(int romID)
        {
            return await _context.Rom.FindAsync(romID);
        }

        public async Task<IEnumerable<Rom>> GetRomsForCore(int coreID)
        {
            return await _context.Rom.Where(w => w.CoreID == coreID).ToListAsync();
        }

        public async Task<Rom> AddRom(Rom rom)
        {
            await _context.AddAsync(rom);
            await _context.SaveChangesAsync();
            return rom;
        }

        public async Task<int> AddRoms(IEnumerable<Rom> roms)
        {
            await _context.AddRangeAsync(roms);
            return await _context.SaveChangesAsync();
        }

        #endregion

        #region ===== SystemSetting =======================

        public async Task<SystemSetting> SaveSystemSetting(SystemSettingEnum settingName, string settingValue)
        {
            return await SaveSystemSetting(settingName.Value, settingValue);
        }

        public async Task<SystemSetting> SaveSystemSetting(string settingName, string settingValue)
        {
            try
            {
                var setting = (await this.GetSystemSettings()).Where(w => w.Name == settingName).FirstOrDefault();
                if (setting != null)
                {
                    setting.Value = settingValue;
                    await _context.SaveChangesAsync();
                    return setting;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return new SystemSetting(); // empty if failed to return above
        }

        public async Task InitSystemSetting(string settingName, string dataType, bool isRequired, bool isReadOnly)
        {
            try
            {
                var setting = await _context.SystemSetting.Where(w => w.Name == settingName).FirstOrDefaultAsync();
                if(setting == null)
                {
                    setting = new SystemSetting
                    {
                        Name = settingName,
                        DataType = dataType,
                        IsRequired = isRequired,
                        IsReadOnly = isReadOnly
                    };
                    _context.SystemSetting.Add(setting);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        public async Task<IEnumerable<SystemSetting>> SaveSystemSettings(IEnumerable<SystemSetting> settings)
        {
            try
            {
                _context.Add(settings);
                await _context.SaveChangesAsync();
                return settings;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }


        public async Task<string?> GetSystemSettingValue(string setting)
        {
            try
            {
                return await _context.Database.SqlQuery<string>($"SELECT Value FROM SystemSetting where Name = {setting}").FirstOrDefaultAsync();
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        #endregion

        #region ===== JobQueue ============================
        public async Task<IEnumerable<JobQueue>> GetNewJobs()
        {
            return await _context.JobQueue
                .Where(w => w.DatePickedUp == null)
                .ToListAsync();
        }

        public Task<IEnumerable<JobQueue>> GetNewJobs(string jobCode)
        {
            throw new NotImplementedException();
        }

        public Task<JobQueue> CreateJob(string jobCode)
        {
            throw new NotImplementedException();
        }

        public Task<JobQueue> StartJob(int jobQueueID)
        {
            throw new NotImplementedException();
        }

        public Task<JobQueue> UpdateJobProgress(int jobQueueID, int percent)
        {
            throw new NotImplementedException();
        }

        public Task<JobQueue> FinishJob(int jobQueueID)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
