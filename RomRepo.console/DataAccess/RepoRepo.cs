using Microsoft.EntityFrameworkCore;
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

        public RepoRepo(RomRepoContext context)
        {
            _context = context;
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
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //log or something
                throw ex;
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
            catch(Exception ex)
            {
                //log
                throw ex;
            }
        }


        public async Task<string?> GetSystemSetting(SystemSettingEnum setting)
        {
            try
            {
                return await _context.Database.SqlQuery<string>($"SELECT Value FROM SystemSetting where Name = {setting.Value}").FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                //log or something
                throw ex;
            }
        }

        public async Task<IEnumerable<SystemSetting>> GetSystemSettings()
        {
            try
            {
                return await _context.SystemSetting.ToListAsync();
            }
            catch(Exception ex)
            {
                //log or something
                throw ex;
            }
        }

        public void GetAllCores()
        {
            throw new NotImplementedException();
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
