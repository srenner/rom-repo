using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomRepo.service
{
    /// <summary>
    /// Launches the IScopedProcessingService that was defined in Program.cs
    /// </summary>
    /// <param name="serviceScopeFactory"></param>
    /// <param name="logger"></param>
    public sealed class ScopedBackgroundService(
        IServiceScopeFactory serviceScopeFactory,
        ILogger<ScopedBackgroundService> logger) : BackgroundService
    {
        private const string ClassName = nameof(ScopedBackgroundService);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(
                "{Name} is running.", ClassName);

            await DoWorkAsync(stoppingToken);
        }

        private async Task DoWorkAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(
                "{Name} is working.", ClassName);

            using (IServiceScope scope = serviceScopeFactory.CreateScope())
            {
                IScopedProcessingService scopedProcessingService =
                    scope.ServiceProvider.GetRequiredService<IScopedProcessingService>();

                await scopedProcessingService.DoWorkAsync(stoppingToken);
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(
                "{Name} is stopping.", ClassName);

            await base.StopAsync(stoppingToken);
        }
    }
}
