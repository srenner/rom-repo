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
        Task UpdateCore(Core coreID);

        #endregion


        #region ===== Rom =================================

        void GetRom(int romID);
        void GetRomsForCore(int coreID);
        void UpdateRom(int romID);

        #endregion


        #region ===== SystemSetting =======================

        /// <summary>
        /// Performs raw sql upsert
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="settingValue"></param>
        /// <returns></returns>
        Task<SystemSetting> SaveSystemSetting(SystemSettingEnum setting, string settingValue);
        
        Task<IEnumerable<SystemSetting>> SaveSystemSettings(IEnumerable<SystemSetting> settings);

        Task<string?> GetSystemSetting(SystemSettingEnum setting);
        Task<IEnumerable<SystemSetting>> GetSystemSettings();

        #endregion

    }
}
