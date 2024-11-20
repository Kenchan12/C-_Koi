using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using KoiFishManager.Api.Data;
using KoiFishManager.Api.Extensions;

namespace KoiFishManager.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigrateDbContext<KoiFishManagerDbContext>((context, services) =>
            {
                var logger = services.GetService<ILogger<KoiFishManagerDbContextSeed>>();
                new KoiFishManagerDbContextSeed().SeedAsync(context, logger).Wait();
            });
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
       
    }
}
