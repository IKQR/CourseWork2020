using GameBlog.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;

namespace GameBlog.Initializer
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var context = services.GetRequiredService<GameBlogDbContext>();
            var userManager = services.GetRequiredService<UserManager<User>>();
            var rolesManager = services.GetRequiredService<RoleManager<Role>>();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            await ImageInitializer.InitializeAsync(new AvatarImageRepository(context));

            await GamesInitializer.InitializeAsync(new GameRepository(context));

            await RoleInitializer.InitializeAsync(userManager, rolesManager);


        }
    }
}

