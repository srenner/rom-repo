﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.DataAccess
{
    public class ClientRepo : IClientRepo
    {
        private readonly RomRepoContext _context;
        private readonly ILogger<ClientRepo> _logger;

        public ClientRepo(RomRepoContext context, ILogger<RomRepo.console.DataAccess.ClientRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        #region ===== Core ================================

        public void GetCore(int coreID)
        {
            throw new NotImplementedException();
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

        public void GetRom(int romID)
        {
            throw new NotImplementedException();
        }

        public void GetRomsForCore(int coreID)
        {
            throw new NotImplementedException();
        }

        public void UpdateRom(int romID)
        {
            throw new NotImplementedException();
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
                using var transaction = _context.Database.BeginTransaction();
                int rows = await _context.Database.ExecuteSqlAsync($"REPLACE INTO SystemSetting(Name, Value) VALUES ({settingName}, {settingValue});");
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                if (rows == 1)
                {
                    return new SystemSetting { Name = settingName, Value = settingValue };
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

    }
}
