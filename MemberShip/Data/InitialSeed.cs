using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Membership.Enums;
using Microsoft.AspNetCore.Identity;

namespace Membership.Data
{
    public class InitialSeed
    {
        public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            foreach (Role role in Enum.GetValues(typeof(Role)))
            {
                IdentityRole roleObj = new IdentityRole()
                {
                    Name = role.ToString()
                };
                await roleManager.CreateAsync(roleObj);
            }

            //Seed sale
            var defaultUser = new IdentityUser
            {
                UserName = "sale@gmail.com",
                Email = "sale@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Pass@1234");
                    await userManager.AddToRoleAsync(defaultUser, Role.Sale.ToString());
                }
            }

            //Seed manager
            defaultUser = new IdentityUser
            {
                UserName = "manager@gmail.com",
                Email = "manager@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Pass@1234");
                    await userManager.AddToRoleAsync(defaultUser, Role.Manager.ToString());
                }
            }
        }
    }
}
