using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using RomRepo.service;
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
        private readonly IAppService _appService;
        private readonly string _userFilesRoot = "/app-userfiles"; // must match with docker-compose.yml
        private IEnumerable<Task> _fileWatcherCollection;

        private FileSystemWatcher _watcher;
        private List<SystemSetting> _settings;

        public RomRepoHostedService(ILogger<RomRepoHostedService> logger, 
                                    IHostApplicationLifetime appLifetime, 
                                    IClientRepo repo, 
                                    ICoreService coreService,
                                    IAppService appService)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _repo = repo;
            _coreService = coreService;
            _appService = appService;
        }

        private async Task<bool> Initialize()
        {
            bool isReady = true;

            _settings = (await _appService.InitSystemSettings()).ToList();

            var uniqueIDSetting = _settings.Where(f => f.Name == SystemSettingEnum.UniqueIdentifier.Value).FirstOrDefault();
            if (string.IsNullOrWhiteSpace(uniqueIDSetting.Value))
            {
                string uniqueID = Guid.NewGuid().ToString();
                uniqueIDSetting.Value = uniqueID;
                await _repo.SaveSystemSetting(uniqueIDSetting.Name, uniqueIDSetting.Value);
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

                var romRootFolder = _settings.Where(w => w.Name ==  SystemSettingEnum.RomRootFolder.Value).FirstOrDefault();
                if(romRootFolder != null)
                {
                    var cores = await _repo.GetAllCores();

                    FileSystemPoller<Core> corePoller = new FileSystemPoller<Core>(romRootFolder.Value);
                    var coreTask = corePoller.ScanAsync(cores);
                    coreTask.Start();

                    ; //breakpoint
                    

                    coreTask.Wait();

                }
                isReady = true;
            }
            else
            {
                Console.WriteLine("Container Error: Check Docker Volume Settings");
            }
            Console.WriteLine("----------------------------------------------");

            _settings.ForEach(x => x.PropertyChanged += Setting_ValueChanged);
            return isReady;
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
