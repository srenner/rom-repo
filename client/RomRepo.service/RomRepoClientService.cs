using Microsoft.Extensions.Caching.Memory;
using RomRepo.console;
using RomRepo.console.Models;
using RomRepo.service.Services.Interfaces;
using RomRepo.service.Workers;

namespace RomRepo.service
{
    public sealed class RomRepoClientService(
                                    ICoreService coreService,
                                    IAppService appService,
                                    IMemoryCache memoryCache,
                                    IJobService jobService) : IScopedProcessingService
    {
        private List<SystemSetting> _settings;
        private IEnumerable<Core> _cores;
        private readonly string _userFilesRoot = "/app-userfiles"; // must match with docker-compose.yml
        private readonly int _loopDelay = 2000;

        public async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            if (await Initialize())
            {
                var newCores = await coreService.DiscoverCores();
                if(newCores?.Count() > 0)
                {
                    foreach (var coreFolder in newCores)
                    {
                        var core = coreFolder.FromDirectoryInfo();
                        if(core != null)
                        {
                            await coreService.AddCore(core);
                        }
                    }
                }
                _cores = await coreService.GetActiveCores();
                
                while (!stoppingToken.IsCancellationRequested)
                {
                    var timer = Task.Delay(_loopDelay);
                    if (!memoryCache.TryGetValue("settings", out _settings))
                    {
                        _settings = await appService.InitSystemSettings();
                    }

                    var newJobs = await jobService.GetNewJobs();
                    foreach(var newJob in newJobs)
                    {
                        switch(newJob.JobCode)
                        {
                            case "unpack":
                                //unzips each rom for a core and returns to user as a single zip file
                                break;
                            case "zip":
                                //zips each rom for a core and returns to user as a single zip file
                                break;
                            case "checksum":
                                //checks checksum values for each rom in the core and writes result to db
                                break;
                            case "filescan":
                                //checks core folder for new/removed/changed roms
                                break;
                            default:
                                break;
                        }
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
