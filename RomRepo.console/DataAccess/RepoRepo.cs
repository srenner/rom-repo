using Microsoft.EntityFrameworkCore;
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

        public async Task<int> SaveSystemSetting(SystemSettingEnum setting, string settingValue)
        {
            try
            {
                int rows = await _context.Database.ExecuteSqlAsync($"REPLACE INTO SystemSetting(Name, Value) VALUES ({setting.Value}, {settingValue});");
                await _context.SaveChangesAsync();
                return rows;
            }
            catch (Exception ex)
            {
                //log or something
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

        public void GetSystemSettings()
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
