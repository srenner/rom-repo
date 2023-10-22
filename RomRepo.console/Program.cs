using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;

namespace RomRepo.console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("RomRepo.console is starting up at " + DateTime.Now.ToLongTimeString());


            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            Task webTask = app.RunAsync();

            await Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
                    var config = builder.Build();
                    services.AddHostedService<RomRepoHostedService>();
                    services.AddOptions();
                })
                .RunConsoleAsync();
            webTask.Wait();
            Console.WriteLine("RomRepo.console is shutting down at " + DateTime.Now.ToLongTimeString());
        }
    }
}