using DataAccessLayer.IdentityModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbContext
{
    public enum Enums
    {
       Admin=1,
       Basic=2
    }

    public static class DataSeed
    {
        
        public static async Task SeedRolesAsync(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Basic.ToString()));
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FullName = "Admin Ji",
                Bank = "Kotak",
                AccountNumber = "123456789121",
                PanNumber = "HHZPQ1111K",
                //EmailConfirmed = true,
               // PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Admin@12345");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Admin.ToString());
                }
            }
        }

        public static async Task SeedBasicAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "basic@gmail.com",
                Email = "basic@gmail.com",
                FullName = "Basic Ji",
                Bank = "Yes Bank",
                AccountNumber = "123456789021",
                PanNumber = "HHZPQ1221K",
                //EmailConfirmed = true,
                //PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Basic@12345");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Basic.ToString());
                }
            }
        }
    }
}
