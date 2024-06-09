using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RomRepo.console;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using RomRepo.console.Services;
using RomRepo.service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services
{
    public class AppService : IAppService
    {
        private readonly ILogger<AppService> _logger;
        private readonly IClientRepo _repo;
        private readonly IMemoryCache _memoryCache;

        public AppService(ILogger<AppService> logger, IClientRepo repo, IMemoryCache memoryCache)
        {
            _logger = logger;
            _repo = repo;
            _memoryCache = memoryCache;
        }

        public async Task<string?> GetSystemSettingValue(string settingName)
        {
            return await _repo.GetSystemSettingValue(settingName);
        }

        public async Task<string?> GetSystemSettingValue(SystemSettingEnum settingEnum)
        {
            var settingName = settingEnum.Value;
            return await this.GetSystemSettingValue(settingName);
        }

        public async Task<List<SystemSetting>> GetSystemSettings(bool updateCache = true)
        {
            var settings = (await _repo.GetSystemSettings()).ToList();
            if(updateCache)
            {
                this.UpdateSettingsCache(settings);
            }
            return settings;
        }

        public async Task<List<SystemSetting>> InitSystemSettings()
        {
            await _repo.InitSystemSetting("UniqueIdentifier", "string", true, true);
            await _repo.InitSystemSetting("SendAnalytics", "bool", false, false);
            await _repo.InitSystemSetting("UseApi", "bool", false, false);
            await _repo.InitSystemSetting("RomRootFolder", "path", true, false);
            await _repo.InitSystemSetting("SavesRootFolder", "path", false, false);
            await _repo.InitSystemSetting("SaveStatesRootFolder", "path", false, false);
            await _repo.InitSystemSetting("ApiKey", "string", false, true);

            return await this.GetSystemSettings();
        }

        public async Task<List<SystemSetting>> SaveSystemSetting(string settingName, string settingValue, bool updateCache = true)
        {
            var updatedSetting = await _repo.SaveSystemSetting(settingName, settingValue);
            if(updateCache)
            {
                await UpdateSettingsCache();
            }
            return await this.GetSystemSettings();
        }

        /// <summary>
        /// Fetches all settings from database and places in cache
        /// </summary>
        /// <returns></returns>
        private async Task UpdateSettingsCache()
        {
            var settings = await this.GetSystemSettings();
            this.UpdateSettingsCache(settings);
        }

        /// <summary>
        /// Place the supplied setting list in cache
        /// </summary>
        /// <param name="settings"></param>
        private void UpdateSettingsCache(List<SystemSetting> settings)
        {
            _memoryCache.Set("settings", settings);
        }

    }
}
