﻿using RomRepo.console;
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
        Task<string?> GetSystemSettingValue(string settingName);
        Task<SystemSetting> GetSystemSetting(SystemSettingEnum settingEnum, string defaultValue = "");
        Task<IEnumerable<SystemSetting>> InitSystemSettings();

    }
}