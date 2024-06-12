using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using RomRepo.console;
using RomRepo.console.Models;
using RomRepo.service.Services;
using RomRepo.service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service
{
    public sealed class RomRepoClientService(
                                    ICoreService coreService,
                                    IAppService appService,
                                    IMemoryCache memoryCache) : IScopedProcessingService
    {
        private List<SystemSetting> _settings;
        private readonly string _userFilesRoot = "/app-userfiles"; // must match with docker-compose.yml

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            if (await Initialize())
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var timer = Task.Delay(2000);
                    if (!memoryCache.TryGetValue("settings", out _settings))
                    {
                        _settings = await appService.InitSystemSettings();
                    }
                    await timer;
                }
            }
            else
            {
                Console.WriteLine("Service Initialization Failed");
            }
        }

        private async Task<bool> Initialize()
        {
            bool isReady = true;
            _settings = await appService.InitSystemSettings();

            var uniqueIDSetting = _settings.Where(f => f.Name == SystemSettingEnum.UniqueIdentifier.Value).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(uniqueIDSetting.Value))
            {
                string uniqueID = Guid.NewGuid().ToString();
                _settings = await appService.SaveSystemSetting(SystemSettingEnum.UniqueIdentifier.Value, uniqueID, updateCache: true);
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("SYSTEM SETTINGS:");
            Console.WriteLine("---");
            PrintSettings();

            if (Directory.Exists(_userFilesRoot))
            {
                Console.WriteLine("---");
                var webClientURL = "http://localhost:5173";
                var settingsURL = webClientURL + "/settings";
                Console.WriteLine("Visit " + settingsURL);
                isReady = true;
            }
            else
            {
                Console.WriteLine("Container Error: Check Docker Volume Settings");
            }
            Console.WriteLine("----------------------------------------------");
            return isReady;
        }

        private void PrintSettings()
        {
            if(_settings?.Count > 0)
            {
                foreach (var item in _settings)
                {
                    var name = item.Name.PadRight(25);
                    string val = !string.IsNullOrWhiteSpace(item.Value) ? item.Value : "null";
                    Console.WriteLine(name + ": " + val);
                }
            }
        }

    }
}
