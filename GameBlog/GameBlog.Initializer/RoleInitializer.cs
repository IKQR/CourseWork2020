using GameBlog.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GameBlog.Initializer
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            string adminEmail = "Admin@gmail.com";
            string adminPassword = "_Aa123456";

            string moderathorEmail = "moderathor@gmail.com";
            string moderathorPassword = "_Mm123456";

            string userEmail = "User@gmail.com";
            string userPassword = "_Uu123456";

            User admin = new User { Email = adminEmail, UserName = adminEmail, AvatarImageId = 1 };
            User moderathor = new User { Email = moderathorEmail, UserName = moderathorEmail, AvatarImageId = 1 };
            User user = new User { Email = userEmail, UserName = userEmail, AvatarImageId = 1 };

            if (await roleManager.FindByNameAsync("default") == null)
            {
                await roleManager.CreateAsync(new Role("default"));
            }
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new Role("admin"));
            }
            if (await roleManager.FindByNameAsync("moderathor") == null)
            {
                await roleManager.CreateAsync(new Role("moderathor"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, "admin");
            }
            if (await userManager.FindByNameAsync(moderathorEmail) == null)
            {
                var result = await userManager.CreateAsync(moderathor, moderathorPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(moderathor, "moderathor");
            }
            if (await userManager.FindByNameAsync(userEmail) == null)
            {
                var result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, "default");
            }
        }
    }
}