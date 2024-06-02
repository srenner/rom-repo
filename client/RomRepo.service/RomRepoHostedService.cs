using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using RomRepo.service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.console
{
    internal sealed class RomRepoHostedService : IHostedService
    {
        private readonly ILogger _logger;
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IClientRepo _repo;
        private readonly ICoreService _coreService;
        private readonly string _userFilesRoot = "/app-userfiles"; // must match with docker-compose.yml

        private FileSystemWatcher _watcher;
        private List<SystemSetting> _settings;

        public RomRepoHostedService(ILogger<RomRepoHostedService> logger, IHostApplicationLifetime appLifetime, IClientRepo repo, ICoreService coreService)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _repo = repo;
            _coreService = coreService;
        }

        private async Task<bool> Initialize()
        {
            bool isReady = true;
            _settings = (await _repo.GetSystemSettings()).ToList();
            var settingUniqueID = _settings.Where(w => w.Name == SystemSettingEnum.UniqueIdentifier.Value).FirstOrDefault();
            if(settingUniqueID == null)
            {
                string uniqueID = Guid.NewGuid().ToString();
                _settings.Add(await _repo.SaveSystemSetting(SystemSettingEnum.UniqueIdentifier, uniqueID));
                Console.WriteLine("Welcome to RomRepo. Your Installation ID is " + uniqueID + "\n");
            }

            if (Directory.Exists(_userFilesRoot))
            {
                var webClientURL = "http://localhost:5174";
                var settingsURL = webClientURL + "/settings";
                Console.WriteLine("Visit " + settingsURL);

                isReady = true;

            }
            else
            {
                Console.WriteLine("Container Error");
            }


            if (false)
            {
                //await _coreService.FindAndAddCores(romRootFolder);

                _watcher = new FileSystemWatcher("romRootFolder");
                _watcher.NotifyFilter = NotifyFilters.Attributes
                                     | NotifyFilters.CreationTime
                                     | NotifyFilters.DirectoryName
                                     | NotifyFilters.FileName
                                     | NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.Security
                                     | NotifyFilters.Size;

                _watcher.Filter = "*.*";
                _watcher.IncludeSubdirectories = true;
                _watcher.EnableRaisingEvents = true;
                _watcher.Created += Watcher_Event;
                _watcher.Changed += Watcher_Event;
                _watcher.Deleted += Watcher_Event;
                _watcher.Renamed += Watcher_Event;
            }
            _settings.ForEach(x => x.PropertyChanged += Setting_ValueChanged);
            return isReady;
        }

        private void Watcher_Event(object sender, FileSystemEventArgs e)
        {

            _logger.LogInformation(e.ChangeType.ToString() + ": " + e.FullPath);

        }

        private async Task SendReceiveAnalytics()
        {
            throw new NotImplementedException();
        }

        private async Task InitSystemMaintenance()
        {
            throw new NotImplementedException();
        }

        #region service lifecycle events

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    bool isReady = false;
                    int retryCounter = 0;

                    while(isReady == false && retryCounter < 10)
                    {
                        isReady = await Initialize();
                        if (!isReady) await Task.Delay(5000);
                        retryCounter++;
                    }

                    if(!isReady)
                    {
                        _logger.LogError("Could not initialize");
                    }
                    else
                    {
                        //using(_watcher)
                        {
                            while (true)
                            {
                                //Console.WriteLine("service running at " + DateTime.Now.ToLongTimeString());
                                await Task.Delay(1000);
                            }
                        }
                    }
                    
                });
            });
            return Task.CompletedTask;
        }

        private void Setting_ValueChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _logger.LogInformation("Setting changed: " + e.PropertyName);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop Requested");
            return Task.CompletedTask;
        }

        #endregion
    }

}
