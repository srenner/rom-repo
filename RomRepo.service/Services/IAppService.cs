using RomRepo.console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service.Services
{
    public interface IAppService
    {
        Task<string> GetSystemSettingValue(string settingName, string defaultValue = "");

        Task<string> GetSystemSettingValue(SystemSettingEnum settingName, string defaultValue = "");

    }
}
