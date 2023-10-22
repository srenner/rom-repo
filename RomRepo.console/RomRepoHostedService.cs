using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
        

        public RomRepoHostedService(ILogger<RomRepoHostedService> logger, IHostApplicationLifetime appLifetime)
        {
            _logger = logger;
            _appLifetime = appLifetime;
        }

        private async Task<bool> Initialize()
        {
            bool isReady = true;
            
            //wait for api ping
            //get user settings (root folders, etc.)
            //check database integrity
            //reset any existing file system watchers
            
            // check for existance of unique identifier in database
            bool hasUniqueIdentifier = false;
            if(!hasUniqueIdentifier)
            {
                var uniqueIdentifier = Guid.NewGuid().ToString();
                Console.WriteLine("Welcome to RomRepo. Your Installation ID is " + uniqueIdentifier);
            }

            //check for existance of root game/rom location
            bool hasRomRootFolder = false;
            if(!hasRomRootFolder)
            {
                Console.Write(@"Where is the root folder for your Rom library? (e.g. \\mister\sdcard): ");
                string romRootFolder = Console.ReadLine();

                if(romRootFolder != null)
                {
                    var fi = new DirectoryInfo(@romRootFolder);
                    if(fi.Exists)
                    {
                        Console.WriteLine("found it");
                    }
                    else
                    {
                        Console.WriteLine("can't connect");
                    }
                }

            }
            return isReady;
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
                        while (true)
                        {
                            //_logger.LogInformation("service running at " + DateTime.Now.ToLongTimeString());
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
