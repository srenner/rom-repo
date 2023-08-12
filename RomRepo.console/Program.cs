using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RomRepo.console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("RomRepo.console is starting up at " + DateTime.Now.ToLongTimeString());

            await Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                    var config = builder.Build();
                    services.AddHostedService<RomRepoHostedService>();
                    services.AddOptions();
                })
                .RunConsoleAsync();
            Console.WriteLine("Shutting down at " + DateTime.Now.ToLongTimeString());
        }
    }
}