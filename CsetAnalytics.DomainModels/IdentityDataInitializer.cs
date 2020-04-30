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
        public static async Task SeedRoles(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync
                (RolesEnum.User.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = RolesEnum.User.ToString();
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
                (RolesEnum.Admin.ToString()).Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = RolesEnum.Admin.ToString();
                IdentityResult roleResult = roleManager.
                    CreateAsync(role).Result;
            }

            //if (!roleManager.Roles.Any())
            //{
            //    foreach (RolesEnum role in Enum.GetValues(typeof(RolesEnum)))
            //    {
            //        var newRole = new IdentityRole();
            //        newRole.Name = role.ToString();
            //        roleManager.CreateAsync(newRole);
            //    }
            //}

        }
    }
}
