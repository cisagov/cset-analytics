using System;
using System.Linq;
using System.Threading.Tasks;
using CsetAnalytics.DomainModels.Models;
using CsetAnalytics.Enums;
using Microsoft.AspNetCore.Identity;

namespace CsetAnalytics.DomainModels
{
    public class IdentityDataInitializer
    {
        public static async Task SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, CsetContext context)
        {
            await SeedRoles(userManager, roleManager);
        }

        public static async Task SeedRoles(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                foreach (RolesEnum role in Enum.GetValues(typeof(RolesEnum)))
                {
                    var newRole = new IdentityRole();
                    newRole.Name = role.ToString();
                    await roleManager.CreateAsync(newRole);
                }
            }

        }
    }
}
