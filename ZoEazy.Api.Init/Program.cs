using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ZoEazy.Api.Data;

namespace ZoEazy.Api.Init
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    logger.LogInformation("Seeding ZoEazy database");
                    var seedAuth = services.GetRequiredService<ISeedData>();
                    seedAuth.Seed(services);

                    var seedProducts = services.GetRequiredService<Data.ISeedData>();
                    seedProducts.Initialize();

                    var context = services.GetRequiredService<ZoeazyDbContext>();
                    
                    var dbInitializerLogger = services.GetRequiredService<ILogger<DbInitializer>>();
                    DbInitializer.Initialize(context, dbInitializerLogger).Wait();

                }   
                catch (Exception ex)
                {
                        logger.LogCritical("Error creating/seeding ZoEazy database - " + ex);
                }
            }

            // host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .ConfigureLogging((hostingContext, logging) =>
                 {
                     logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                     logging.AddConsole();
                     logging.AddDebug();
                     logging.AddEventSourceLogger();
                 })
                 .UseStartup<Startup>();
    }
}
