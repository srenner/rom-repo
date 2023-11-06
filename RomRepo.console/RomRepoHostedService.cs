using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RomRepo.console.DataAccess;
using RomRepo.console.Models;
using RomRepo.console.Services;
using System;
using System.Collections.Generic;
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
        private readonly IRepoRepo _repo;
        private readonly ICoreService _coreService;

        private FileSystemWatcher _watcher;
        private List<SystemSetting> _settings;
        private const string ANALYTICS_HELP_TEXT = "If you choose to share analytics, we may periodically collect information from your SQLite database. " +
                                                    "We will never upload or inspect your rom files. " +
                                                    "We do not have the ability or inclination to determine the legal status of your files. " +
                                                    "Please obey all applicable copyright laws in your area.";

        public RomRepoHostedService(ILogger<RomRepoHostedService> logger, IHostApplicationLifetime appLifetime, IRepoRepo repo, ICoreService coreService)
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
            _settings = _settings.ToList();
            
            var settingUniqueID = _settings.Where(w => w.Name == SystemSettingEnum.UniqueIdentifier.Value).FirstOrDefault();
            if(settingUniqueID == null)
            {
                string uniqueID = Guid.NewGuid().ToString();
                _settings.Add(await _repo.SaveSystemSetting(SystemSettingEnum.UniqueIdentifier, uniqueID));
                Console.WriteLine("Welcome to RomRepo. Your Installation ID is " + uniqueID + "\n");
            }

            var settingSendAnalytics = _settings.Where(w => w.Name == SystemSettingEnum.SendAnalytics.Value).FirstOrDefault();
            if(settingSendAnalytics == null)
            {
                Console.Write("Send Analytics to RomRepo.com? [ Y / ");
                Console.Write("\x1b[1m(N)\x1b[0m");
                Console.Write(" / ? ] : ");

                var key = Console.ReadKey(true);
                if(key.Key == ConsoleKey.Y)
                {
                    Console.Write("Y");
                    _settings.Add(await _repo.SaveSystemSetting(SystemSettingEnum.SendAnalytics, "1"));
                }
                else
                {
                    if(key.KeyChar == '?')
                    {
                        Console.WriteLine("\n" + ANALYTICS_HELP_TEXT);
                    }
                    else
                    {
                        Console.Write("N");
                        _settings.Add(await _repo.SaveSystemSetting(SystemSettingEnum.SendAnalytics, "0"));
                    }
                }
                Console.WriteLine();
            }

            var settingRomRootFolder = _settings.Where(w => w.Name == SystemSettingEnum.RomRootFolder.Value).FirstOrDefault();
            if(settingRomRootFolder == null)
            {
                Console.Write(@"Where is the root folder for your Rom library? (e.g. \\nas\emulation\games): ");
                string inputRomRootFolder = Console.ReadLine();

                if(inputRomRootFolder != null)
                {
                    var fi = new DirectoryInfo(inputRomRootFolder);
                    if(fi.Exists)
                    {
                        Console.WriteLine("found it");
                        _settings.Add(await _repo.SaveSystemSetting(SystemSettingEnum.RomRootFolder, inputRomRootFolder));


                        //


                        foreach (var coreRoot in fi.EnumerateDirectories())
                        {
                            //Console.WriteLine(coreRoot.FullName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("can't connect");
                        isReady = false;
                    }
                }
            }

            var romRootFolder = _settings.Where(w => w.Name == SystemSettingEnum.RomRootFolder.Value).FirstOrDefault()?.Value;

            if (romRootFolder != null)
            {
                //await _coreService.FindAndAddCores(romRootFolder);

                _watcher = new FileSystemWatcher(romRootFolder);
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
                        using(_watcher)
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
            return Task.CompletedTask;
        }

        #endregion
    }

}
