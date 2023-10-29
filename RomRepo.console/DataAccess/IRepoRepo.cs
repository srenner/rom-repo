using Microsoft.EntityFrameworkCore.Query.Internal;
using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console.DataAccess
{
    public interface IRepoRepo
    {
        #region ===== Core ================================
        
        void GetAllCores();
        void GetCore(int coreID);
        void UpdateCore(int coreID);

        #endregion


        #region ===== Rom =================================

        void GetRomsForCore(int coreID);
        void GetRom(int romID);
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
