
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;
using RomRepo.api.Auth;
using RomRepo.api.DataAccess;
using RomRepo.api.Services;
using System.Reflection;

namespace RomRepo.api
{
    /// <summary>Application entry point</summary>
    public class Program
    {
        /// <summary>Application entry point</summary>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<ApiContext>();
            builder.Services.AddScoped<IApiRepository, ApiRepository>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IRomService, RomService>();
            builder.Services.AddScoped<IApiKeyService, ApiKeyService>();
            builder.Services.Configure<KestrelServerOptions>(options => options.Limits.MaxRequestBodySize = int.MaxValue);

            //Remember to enable "GenerateDocumentationFile" in project settings
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "RomRepo.api",
                    Version = "v1"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            builder.Services.AddAuthentication()
                .AddScheme<KeyAuthSchemeOptions, KeyAuthSchemeHandler>(
                "ApiKey",
                opts => { }
            );


            var app = builder.Build();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers().RequireAuthorization();
            app.Run();
        }
    }
}