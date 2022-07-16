using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ZoEazy.Api.Model;
using ZoEazy.Api.Data;
using Microsoft.Extensions.Configuration;
using ZoEazy.Api.Model.Subscriber;

namespace ZoEazy.Api.Init
{
    public interface ISeedData
    {
        void Seed(IServiceProvider serviceProvider);
    }

    public class SeedData : ISeedData
    {

        private readonly UserManager<Subscriber> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public SeedData(RoleManager<ApplicationRole> roleManager, UserManager<Subscriber> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.EnsureDeleted();
                scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.EnsureCreated();
                // scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

                var configContext = scope.ServiceProvider.GetService<ConfigurationDbContext>();
                configContext.Database.Migrate();
                SeedIdentityServerConfigData(configContext);

                // Seeding Users and roles
                var appContext = scope.ServiceProvider.GetService<ZoeazyDbContext>();
                appContext.Database.Migrate();
                CreateRoles();
                CreateUsers(appContext);

            }
        }

        private void SeedIdentityServerConfigData(IConfigurationDbContext context)
        {
                if (!context.Clients.Any())
            {
                var clientUrls = Startup.Configuration["ClientUrls"];

                foreach (var client in Config.GetClients(clientUrls).ToList())
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var resource in Config.GetIdentityResources().ToList())
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var resource in Config.GetApiResources().ToList())
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                context.SaveChanges();
            }
        }

        private void CreateRoles()
        {
            var rolesToAdd = new List<ApplicationRole>(){
                new ApplicationRole { Name = "Admin", Description = "Role with full rights" },
                new ApplicationRole { Name = "User", Description = "Role with limited rights" }
            };
            foreach (var role in rolesToAdd)
            {
                if (!_roleManager.RoleExistsAsync(role.Name).Result)
                {
                    _roleManager.CreateAsync(role).Result.ToString();
                }
            }
        }
        private void CreateUsers(ZoeazyDbContext context)
        {
            if (!context.Subscribers.Any())
            {
                var adminUser = new Subscriber
                {
                    UserName = "mdelgadov@hotmail.com",
                    Name = new HumanName("Miguel", "Villar","Delgado"),
                    Email = "mdelgadov@hotmail.com",
                    Mobile = "0123456789",
                    EmailConfirmed = true,
                    CreatedDate = DateTime.Now,
                    IsEnabled = true,
                    Suspended = new Flag(),
                    DateOfBirth = new Date(),
                    IsAdmin = true,
                    Gender = Gender.Male


                };

                _userManager.CreateAsync(adminUser, "VVirals13.8").Result.ToString();
                _userManager.AddClaimAsync(adminUser, new Claim(IdentityServerConstants.StandardScopes.Phone, adminUser.Mobile.ToString(), ClaimValueTypes.Integer)).Result.ToString();
                _userManager.AddToRoleAsync(_userManager.FindByNameAsync("mdelgadov@hotmail.com").GetAwaiter().GetResult(), "Admin").Result.ToString();

                var normalUser = new Subscriber { UserName = "user@user.com",
                    Name = new HumanName("First", "Middle", "Last"),
                    Email = "user@user.com", Mobile = "0123456789",
                    EmailConfirmed = true,
                    CreatedDate = DateTime.Now,
                    IsEnabled = true,
                    Suspended = new Flag(),
                    DateOfBirth = new Date(),
                    IsAdmin = false,
                    Gender = Gender.Male

                };
                _userManager.CreateAsync(normalUser, "P@ssw0rd!").Result.ToString();
                _userManager.AddClaimAsync(adminUser, new Claim(IdentityServerConstants.StandardScopes.Phone, adminUser.Mobile.ToString(), ClaimValueTypes.Integer)).Result.ToString();
                _userManager.AddToRoleAsync(_userManager.FindByNameAsync("user@user.com").GetAwaiter().GetResult(), "User").Result.ToString();
            }
        }
    }
}