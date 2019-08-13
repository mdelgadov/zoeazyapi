using ZoEazy.Api.Data.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
// using AspNetCoreSpa.Infrastructure;
using System.Linq;
// using AspNetCoreSpa.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ZoEazy.Api.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        // https://github.com/aspnet/JavaScriptServices/tree/dev/src/Microsoft.AspNetCore.SpaServices#debugging-your-javascripttypescript-code-when-it-runs-on-the-server
        // Url to visit:
        // chrome-devtools://devtools/bundled/inspector.html?experiments=true&v8only=true&ws=127.0.0.1:9229/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
        public static IServiceCollection AddPreRenderDebugging(this IServiceCollection services, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                services.AddNodeServices(options =>
                {
                    options.LaunchWithDebugging = true;
                    options.DebuggingPort = 9229;
                });
            }

            return services;
        }
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            // https://stackoverflow.com/a/51241314/1190512
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ModelValidationFilter));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            return services;
        }
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContextPool<ZoeazyDbContext>(options =>
            {
                options.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=ZoEazyDb;Integrated Security=True", b =>
                {
                    b.MigrationsAssembly("ZoEazy.Api.Data");
                    // Add foolowing package to enable net topology suite for sql server:
                    // <PackageReference Include = "Microsoft.EntityFrameworkCore.SqlServer.NetTopologySuite" Version = "2.2.0" />
                    //b.UseNetTopologySuite();
                });
            });
            return services;
        }

        
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            // New instance every time, only configuration class needs so its ok
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ApiExceptionFilter>();
            services.AddInfrastructurServices();
            return services;
        }

    }
}
