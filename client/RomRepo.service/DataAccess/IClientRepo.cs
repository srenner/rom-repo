using Microsoft.EntityFrameworkCore.Query.Internal;
using RomRepo.console.Models;
using RomRepo.service.Models;
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

        Task<Core?> GetCore(int coreID);
        Task<IEnumerable<Core>> GetAllCores();
        Task<IEnumerable<Core>> GetActiveCores();
        Task<IEnumerable<Core>> GetInactiveCores();

        Task<int> AddCores(IEnumerable<Core> cores);
        Task<bool> UpdateCore(Core coreID);

        #endregion


        #region ===== Rom =================================

        Task<Rom> GetRom(int romID);

        Task<IEnumerable<Rom>> GetRomsForCore(int coreID);
        Task<Rom> AddRom(Rom rom);
        Task<int> AddRoms(IEnumerable<Rom> roms);

        #endregion


        #region ===== SystemSetting =======================

        Task<SystemSetting> SaveSystemSetting(SystemSettingEnum setting, string settingValue);
        Task<SystemSetting> SaveSystemSetting(string settingName, string settingValue);
        Task InitSystemSetting(string settingName, string dataType, bool isRequired, bool isReadOnly);


        Task<IEnumerable<SystemSetting>> SaveSystemSettings(IEnumerable<SystemSetting> settings);

        //Task<string?> GetSystemSetting(SystemSettingEnum setting);
        Task<string?> GetSystemSettingValue(string setting);
        
        Task<IEnumerable<SystemSetting>> GetSystemSettings();

        #endregion

        #region ===== JobQueue ============================

        Task<IEnumerable<JobQueue>> GetNewJobs();
        Task<IEnumerable<JobQueue>> GetNewJobs(string jobCode);
        Task<JobQueue> CreateJob(string jobCode);
        Task<JobQueue> StartJob(int jobQueueID);
        Task<JobQueue> UpdateJobProgress(int jobQueueID, int percent);
        Task<JobQueue> FinishJob(int jobQueueID);

        #endregion

    }
}
