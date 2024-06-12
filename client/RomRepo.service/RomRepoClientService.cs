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
            foreach (var item in _settings)
            {
                var name = item.Name.PadRight(25);
                string val = !string.IsNullOrWhiteSpace(item.Value) ? item.Value : "null";
                Console.WriteLine(name + ": " + val);
            }

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

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            await Initialize();
            while (!stoppingToken.IsCancellationRequested)
            {
                var timer = Task.Delay(2000);

                //memory cache not working properly yet
                if (!memoryCache.TryGetValue("settings", out _settings))
                {
                    _settings = await appService.InitSystemSettings();
                }

                foreach (var item in _settings)
                {
                    var name = item.Name.PadRight(25);
                    string val = !string.IsNullOrWhiteSpace(item.Value) ? item.Value : "null";
                    Console.WriteLine(name + ": " + val);
                }

                //check for settings changes
                /*
                    UniqueIdentifier        - well that's weird
                    SendAnalytics           - conditionally SendReceiveAnalytics()
                    UseApi                  - calculate hashes & check validity
                    RomRootFolder           - complete rescan of cores and roms 
                    SavesRootFolder         - not implemented
                    SaveStatesRootFolder    - not implemented
                    ApiKey                  - well that's weird
                */

                Console.WriteLine("service running at " + DateTime.Now.ToLongTimeString());



                await timer;
            }
        }
    }
}
