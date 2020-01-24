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
            await SeedUsers(userManager, context);

        }

        public static async Task SeedUsers(UserManager<ApplicationUser> userManager, CsetContext context)
        {

            if (await userManager.FindByNameAsync
                    ("jkuipers") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "jkuipers";
                user.Email = "jkuipers@inl.gov";

                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd!").Result;
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, RolesEnum.Admin.ToString());
                }
            }

            var users = context.Users;
            foreach (var u in users)
            {
                var role = context.UserRoles.FirstOrDefault(x => x.UserId == u.Id);
                if (role == null)
                {
                    await userManager.AddToRoleAsync(u, RolesEnum.User.ToString());
                }
            }
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
