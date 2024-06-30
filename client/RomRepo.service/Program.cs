using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using System;
using System.Text;
using RomRepo.console.DataAccess;
using RomRepo.console.Services;
using RomRepo.service.Services;
using Microsoft.AspNetCore.Hosting;
using RomRepo.service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using RomRepo.service;
using RomRepo.service.Workers;

namespace RomRepo.console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("RomRepo.service is starting up at " + DateTime.Now.ToLongTimeString());
            PrintBanner();

            var builder = WebApplication.CreateBuilder(args);
            //builder.WebHost.UseUrls("http://*:5000;https://*:5001");
            builder.WebHost.UseUrls("http://*:5000");
            
            //NOT SURE YET:
            //builder.WebHost.ConfigureKestrel(serverOptions =>
            //{
            //    serverOptions.Limits.MaxResponseBufferSize = null;
            //});
            builder.Logging.ClearProviders();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<RomRepoContext>();
            builder.Services.AddScoped<IClientRepo, ClientRepo>();
            builder.Services.AddScoped<IAppService, AppService>();
            builder.Services.AddScoped<IRomService, RomService>();
            builder.Services.AddScoped<ICoreService, CoreService>();
            builder.Services.AddScoped<IJobService, JobService>();
            builder.Services.AddMemoryCache();
            
            //create a scope for the background service
            builder.Services.AddHostedService<ScopedBackgroundService>();
            builder.Services.AddScoped<IScopedProcessingService, RomRepoClientService>();

            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<RomRepoContext>())
                {
                    //context.Database.Migrate();
                }
            }

            Task webTask = app.RunAsync();
            string baseURL = "http://localhost:5000";
            //baseURL = app.Urls.First();
            Console.WriteLine("API Listening at " + baseURL);

            try
            {
                HttpClient client = new HttpClient();
                string responseBody = await client.GetStringAsync(baseURL + "/api/app/version");
                Console.WriteLine("API Version " + responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception :{0} ", e.Message);
            }

            Console.WriteLine("----------------------------------------------\n");
            webTask.Wait();
            Console.WriteLine("RomRepo.service is shutting down at " + DateTime.Now.ToLongTimeString());
        }

        private static void PrintBanner()
        {
            Console.WriteLine("");
            Console.WriteLine(" _____                 _____                  ");
            Console.WriteLine("|  __ \\               |  __ \\                 ");
            Console.WriteLine("| |__) |___  _ __ ___ | |__) |___ _ __   ___  ");
            Console.WriteLine("|  _  // _ \\| '_ ` _ \\|  _  // _ \\ '_ \\ / _ \\ ");
            Console.WriteLine("| | \\ \\ (_) | | | | | | | \\ \\  __/ |_) | (_) |");
            Console.WriteLine("|_|  \\_\\___/|_| |_| |_|_|  \\_\\___| .__/ \\___/ ");
            Console.WriteLine("                                 | |          ");
            Console.WriteLine("          repo for roms          |_|          ");
            Console.WriteLine("----------------------------------------------");
        }

    }
}