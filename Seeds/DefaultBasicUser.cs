using KhadimiEssa.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static AAITHelper.HelperDate;

namespace KhadimiEssa.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationDbUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationDbUser
            {
                UserName = "aait@aait.sa",
                Email = "aait@aait.sa",
                user_Name = "aait@aait.sa",
                ShowPassword = "123456",
                TypeUser = (int)Enums.AllEnums.User_Type.AdminBranch,
                ActiveCode = true,
                PublishDate = GetCurrentDate(),
                IsActive = true,
                ImgProfile = "Images/Users/Default.Png",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123456");
                await userManager.AddToRoleAsync(defaultUser, Enums.AllEnums.Roles.AdminBranch.ToString());
            }
            else
            {
                if (!await userManager.IsInRoleAsync(user, Enums.AllEnums.Roles.AdminBranch.ToString()))
                {
                    await userManager.AddToRoleAsync(user, Enums.AllEnums.Roles.AdminBranch.ToString());
                }
            }


        }
    }
}
