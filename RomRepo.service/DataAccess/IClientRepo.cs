using Microsoft.EntityFrameworkCore.Query.Internal;
using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.DataAccess
{
    public interface IClientRepo
    {
        #region ===== Core ================================

        void GetCore(int coreID);
        Task<IEnumerable<Core>> GetAllCores();
        Task<int> AddCores(IEnumerable<Core> cores);
        Task<bool> UpdateCore(Core coreID);

        #endregion


        #region ===== Rom =================================

        void GetRom(int romID);
        void GetRomsForCore(int coreID);
        void UpdateRom(int romID);

        #endregion


        #region ===== SystemSetting =======================

        Task<SystemSetting> SaveSystemSetting(SystemSettingEnum setting, string settingValue);
        Task<SystemSetting> SaveSystemSetting(string settingName, string settingValue);
        
        Task<IEnumerable<SystemSetting>> SaveSystemSettings(IEnumerable<SystemSetting> settings);

        Task<string?> GetSystemSetting(SystemSettingEnum setting);
        Task<string?> GetSystemSetting(string setting);
        
        Task<IEnumerable<SystemSetting>> GetSystemSettings();

        #endregion

    }
}
