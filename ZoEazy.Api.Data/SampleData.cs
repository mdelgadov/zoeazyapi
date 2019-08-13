using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

using System.Threading.Tasks;
using ZoEazy.Api.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ZoEazy.Api.Data
{
    public class SampleData
    {
        public static async void Initialize(IServiceScope scope)
        {
            var context = scope.ServiceProvider.GetService<ZoeazyDbContext>();

            string[] roles = new string[] { "Owner", "Administrator", "Manager", "Staff", "Customer" };
            var roleStore = new RoleStore<IdentityRole>(context);
            foreach (string role in roles)
            {
                

                if (!context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role));
                }
            }

             context.SaveChanges();
            var user = new Subscriber
            {
                FirstName = "XXXX",
                LastName = "XXXX",
                Email = "xxxx@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "Owner",
                NormalizedUserName = "OWNER",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

           

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<Subscriber>();
                var hashed = password.HashPassword(user, "secret");
                user.PasswordHash = hashed;

                var userStore = new UserStore<Subscriber>(context);
                await userStore.CreateAsync(user);

            }
             context.SaveChanges();
            await AssignRoles(scope, user.Email, roles);

             context.SaveChanges();
        }

        public static async Task AssignRoles(IServiceScope scope, string email, string[] roles)
        {
            var _userManager = scope.ServiceProvider.GetService<UserManager<Subscriber>>();
            var user = await _userManager.FindByEmailAsync(email);
            await _userManager.AddToRolesAsync(user, roles);
        }

    }

}

