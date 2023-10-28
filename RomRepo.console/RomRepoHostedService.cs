using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RomRepo.console.DataAccess;
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
        private FileSystemWatcher _watcher;
        private readonly IRepoRepo _repo;
        

        public RomRepoHostedService(ILogger<RomRepoHostedService> logger, IHostApplicationLifetime appLifetime, IRepoRepo repo)
        {
            _logger = logger;
            _appLifetime = appLifetime;
            _repo = repo;
        }

        private async Task<bool> Initialize()
        {
            bool isReady = true;
            
            //wait for api ping
            //get user settings (root folders, etc.)
            //check database integrity
            //reset any existing file system watchers
            
            bool hasUniqueIdentifier = false;
            if(!hasUniqueIdentifier)
            {
                var uniqueIdentifier = Guid.NewGuid().ToString();
                Console.WriteLine("Welcome to RomRepo. Your Installation ID is " + uniqueIdentifier);
                await _repo.SaveSystemSetting(SystemSettingEnum.UniqueIdentifier, uniqueIdentifier);
            }

            bool analyticsSpecified = false;
            if(!analyticsSpecified)
            {
                Console.Write("Send Analytics to RomRepo.com? [ Y / ");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(" N ");
                Console.ResetColor();
                
                Console.Write(" / ? ] : ");
                var key = Console.ReadKey();

                if(key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine("N");
                }
                else
                {
                    Console.WriteLine();
                }
            }


            bool hasRomRootFolder = false;
            if(!hasRomRootFolder)
            {
                Console.Write(@"Where is the root folder for your Rom library? (e.g. \\mister\sdcard\games): ");
                string romRootFolder = Console.ReadLine();

                if(romRootFolder != null)
                {
                    var fi = new DirectoryInfo(@romRootFolder);
                    if(fi.Exists)
                    {
                        Console.WriteLine("found it");

                        _watcher = new FileSystemWatcher(romRootFolder);
                        _watcher.NotifyFilter = NotifyFilters.Attributes
                                             | NotifyFilters.CreationTime
                                             | NotifyFilters.DirectoryName
                                             | NotifyFilters.FileName
                                             | NotifyFilters.LastAccess
                                             | NotifyFilters.LastWrite
                                             | NotifyFilters.Security
                                             | NotifyFilters.Size;

                        _watcher.Filter = "*.txt";
                        _watcher.IncludeSubdirectories = true;
                        _watcher.EnableRaisingEvents = true;
                        _watcher.Created += Watcher_Event;
                        _watcher.Changed += Watcher_Event;

                        Console.WriteLine("Press the Any key");
                        Console.ReadLine();

                        foreach (var coreRoot in fi.EnumerateDirectories())
                        {
                            Console.WriteLine(coreRoot.FullName);
                        }


                    }
                    else
                    {
                        Console.WriteLine("can't connect");
                        isReady = false;
                    }
                }
            }


            return isReady;
        }

        private void Watcher_Event(object sender, FileSystemEventArgs e)
        {
            string debugger = "stop";
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
                                //_logger.LogInformation("service running at " + DateTime.Now.ToLongTimeString());
                                Console.WriteLine("service running at " + DateTime.Now.ToLongTimeString());
                                await Task.Delay(1000);
                            }
                        }

                    }
                    
                });
            });
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        #endregion
    }

}
