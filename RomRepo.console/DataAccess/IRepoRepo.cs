using Microsoft.EntityFrameworkCore.Query.Internal;
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

        Task<int> SaveSystemSetting(SystemSettingEnum setting, string settingValue);
        Task<string?> GetSystemSetting(SystemSettingEnum setting);

        #endregion

        void GetSystemSettings();


    }
}
