
using Microsoft.AspNetCore.Server.Kestrel.Core;
using RomRepo.api.DataAccess;
using RomRepo.api.Services;

namespace RomRepo.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApiContext>();
            builder.Services.AddScoped<IApiRepository, ApiRepository>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IRomService, RomService>();
            builder.Services.Configure<KestrelServerOptions>(options => options.Limits.MaxRequestBodySize = int.MaxValue);
            var app = builder.Build();
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}