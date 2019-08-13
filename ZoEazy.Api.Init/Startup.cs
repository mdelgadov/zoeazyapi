using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.Services;
using System.Reflection;
using IdentityServer4;
using System;
using Microsoft.AspNetCore.HttpOverrides;
using System.Security.Cryptography.X509Certificates;
using ZoEazy.Api.Model;
//using ZoEazy.Api.STS.Resources;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
//using ZoEazy.Api.STS.Services;
using Microsoft.Extensions.Options;
using ZoEazy.Api.Data;
using ZoEazy.Api.Data.Services;
using ZoEazy.Api.Data.Extensions;

namespace ZoEazy.Api.Init
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            X509Certificate2 cert;
            var connectionString = Configuration.GetConnectionString("ZoeazyConnection");
            var migrationsAssembly = "ZoEazy.Api.Data";
            //var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            //if (Environment.IsProduction())
            //{
            //    // Azure deployment, will be used if deployed to Azure
            //    var vaultConfigSection = Configuration.GetSection("Vault");
            //    var keyVaultService = new KeyVaultCertificateService(vaultConfigSection["Url"], vaultConfigSection["ClientId"], vaultConfigSection["ClientSecret"]);
            //    cert = keyVaultService.GetCertificateFromKeyVault(vaultConfigSection["CertificateName"]);
            //}
            //else
            //{
            // Add framework services.

            var base64EncodedStr = Convert.FromBase64String(Configuration["STSCertificate"]);

            cert = new X509Certificate2(base64EncodedStr, string.Empty, X509KeyStorageFlags.MachineKeySet);
            services.Configure<StsConfig>(Configuration.GetSection("StsConfig"));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            //services.AddSingleton<LocService>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            //services.Configure<RequestLocalizationOptions>(
            //   options =>
            //   {
            //       var supportedCultures = new List<CultureInfo>
            //           {
            //                new CultureInfo("en-US"),
            //                new CultureInfo("de-DE"),
            //                new CultureInfo("de-CH"),
            //                new CultureInfo("it-IT"),
            //                new CultureInfo("gsw-CH"),
            //                new CultureInfo("fr-FR")
            //           };

            //       options.DefaultRequestCulture = new RequestCulture(culture: "de-DE", uiCulture: "de-DE");
            //       options.SupportedCultures = supportedCultures;
            //       options.SupportedUICultures = supportedCultures;

            //       var providerQuery = new LocalizationQueryProvider
            //       {
            //           QureyParamterName = "ui_locales"
            //       };

            //       options.RequestCultureProviders.Insert(0, providerQuery);
            //   });
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
                options.AuthenticationDisplayName = "Windows";
            });

            services.AddDbContextPool<ZoeazyDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(migrationsAssembly));
            });
            services.AddIdentity<Subscriber, ApplicationRole>()
           .AddEntityFrameworkStores<ZoeazyDbContext>()
           .AddDefaultTokenProviders();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", corsBuilder =>
                {
                    corsBuilder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials();
                });
            });


            services.AddTransient<ISeedData, SeedData>();
            services.AddTransient<Data.ISeedData, Data.SeedData>();
            services.AddTransient<ZoeazyDbContext>();
            // services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IProfileService, CustomProfileService>();

            var identityServer = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
                // this adds the config data from DB (clients, resources, CORS)
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly));
                })


                // this adds the operational data from DB (codes, tokens, consents)
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder =>
                        builder.UseSqlServer(connectionString,
                            sql => sql.MigrationsAssembly(migrationsAssembly));

                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                    // options.TokenCleanupInterval = 15; // interval in seconds. 15 seconds useful for debugging
                })
                .AddAspNetIdentity<Subscriber>();
            services.AddAuthentication()
              .AddGoogle(options =>
              {
                  options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                  options.ClientId = "476611152863-ltgqfk9jhq1vsenin5039n58ogkraltb.apps.googleusercontent.com";
                  options.ClientSecret = "rSHvhgdOQUB4KMc5JS1alzhg";
              })
              .AddOpenIdConnect("aad", "Login with Azure AD", options =>
              {
                  options.Authority = $"https://login.microsoftonline.com/common";
                  options.TokenValidationParameters = new TokenValidationParameters { ValidateIssuer = false };
                  options.ClientId = "99eb0b9d-ca40-476e-b5ac-6f4c32bfb530";
                  options.CallbackPath = "/signin-oidc";
                  options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
              });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // https://github.com/openiddict/openiddict-core/issues/518
            // And
            // https://github.com/aspnet/Docs/issues/2384#issuecomment-297980490
            var forwarOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            };
            forwarOptions.KnownNetworks.Clear();
            forwarOptions.KnownProxies.Clear();

            app.UseForwardedHeaders(forwarOptions);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Home/Error");
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            app.UseHttpsRedirection();

            // app.UseMiddleware<AdminSafeListMiddleware>(
            //     Configuration["AdminSafeList"]);

            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            app.UseIdentityServer();

            app.UseMvcWithDefaultRoute();
        }
    }
}
