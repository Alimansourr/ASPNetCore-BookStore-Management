using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Project_Advanced.Models
{
    public static class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {//instances from core identity services
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Define the roles to be created
            string[] roleNames = { "SuperAdmin","Admin", "User" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var superAdminEmail = "superadmin@gmail.com";
            var superAdminPassword = "SuperAdmin123!@#";
            var superAdminPhonenb = "96103000000";

          
            if (await userManager.FindByEmailAsync(superAdminEmail) == null)
            {
                var superAdminUser = new IdentityUser
                {
                    Email = superAdminEmail,
                    UserName = superAdminEmail,
                    PhoneNumber = superAdminPhonenb,
                    EmailConfirmed = true 
                };

              
                var superAdminResult = await userManager.CreateAsync(superAdminUser, superAdminPassword);

                if (superAdminResult.Succeeded)
                {
                    await userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");
                }
            }

            var email = "admin@gmail.com";
            var password = "Admin123!@#";
            var phoneNumber = "96171173125";

           
            if (await userManager.FindByEmailAsync(email) == null)
            {
               
                var user = new IdentityUser
                {
                    Email = email,
                    UserName = email,
                    PhoneNumber = phoneNumber
                };

                // Create the user and add to Admin role
                IdentityResult result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                    user.EmailConfirmed = true; 
                    await userManager.UpdateAsync(user); 
                }
            }
        }
    }
}
