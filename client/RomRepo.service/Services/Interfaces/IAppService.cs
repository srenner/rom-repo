using RomRepo.console;
using RomRepo.console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services.Interfaces
{
    public interface IAppService
    {
        /// <summary>
        /// Gets single setting value as a string from the database
        /// </summary>
        /// <param name="settingName"></param>
        /// <returns></returns>
        Task<string?> GetSystemSettingValue(string settingName);

        /// <summary>
        /// Gets single setting value as a string from the database
        /// </summary>
        /// <param name="settingEnum"></param>
        /// <returns></returns>
        Task<string?> GetSystemSettingValue(SystemSettingEnum settingEnum);
        
        /// <summary>
        /// Gets all settings from database
        /// </summary>
        /// <param name="updateCache"></param>
        /// <returns></returns>
        Task<List<SystemSetting>> GetSystemSettings(bool updateCache = true);

        /// <summary>
        /// Returns all settings after ensuring they are present and placing them in cache
        /// </summary>
        /// <returns></returns>
        Task<List<SystemSetting>> InitSystemSettings();

        /// <summary>
        /// Updates a setting value and optionally updates the settings cache
        /// </summary>
        /// <param name="settingName"></param>
        /// <param name="settingValue"></param>
        /// <param name="updateCache"></param>
        /// <returns></returns>
        Task<List<SystemSetting>> SaveSystemSetting(string settingName, string settingValue, bool updateCache = true);

    }
}
