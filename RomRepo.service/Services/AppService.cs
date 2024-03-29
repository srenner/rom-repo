﻿using Microsoft.Extensions.Logging;
using RomRepo.console;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using RomRepo.console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services
{
    public class AppService : IAppService
    {
        private ILogger<AppService> _logger;
        private IClientRepo _repo;

        public AppService(ILogger<AppService> logger, IClientRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public async Task<SystemSetting> GetSystemSetting(SystemSettingEnum settingEnum, string defaultValue = "")
        {
            var settings = await _repo.GetSystemSettings();
            var setting = settings.Where(w => w.Name == settingEnum.Value).FirstOrDefault();
            if (setting == null)
            {
                return await _repo.SaveSystemSetting(settingEnum, defaultValue);
            }
            else
            {
                return setting;
            }
        }

        public async Task<string?> GetSystemSettingValue(string settingName)
        {
            return await _repo.GetSystemSettingValue(settingName);
        }

    }
}
