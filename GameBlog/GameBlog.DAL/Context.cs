using GameBlog.DAL.Entities;
using GameBlog.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;

namespace GameBlog.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<AuthType>(
                "AuthType",
                new Npgsql.NameTranslation.NpgsqlNullNameTranslator()
            );
            NpgsqlConnection.GlobalTypeMapper.MapEnum<ImageType>(
                "ImageType",
                new Npgsql.NameTranslation.NpgsqlNullNameTranslator()
            );
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ForNpgsqlHasEnum(typeof(AuthType).Name, typeof(AuthType).GetEnumNames());
            builder.ForNpgsqlHasEnum(typeof(ImageType).Name, typeof(ImageType).GetEnumNames());

            // добавляем роли
            Role moderRole = new Role { Id = 1, Name = "moder", Description = "Just Moder"};
            Role userRole = new Role { Id = 2, Name = "user", Description = "Regular User" };
            AvatarImage avatarImage = new AvatarImage { Id = 1, Image = System.IO.File.ReadAllBytes(@"C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.DAL\avatar.png"), Type = ImageType.PNG };
            User moderUser = new User {
                Id = 1,
                Name = "notIlya",
                Email = "kusik@jkl.j",
                Login = "Moder",
                Password = "Moder",
                
                AuthType = AuthType.Default,
                RoleId = moderRole.Id,
                AvatarImageId = 1,
                //LikedPostsId = new List<int>(),
                //PostsId = new List<int>(),
            };
            User defailtUser = new User {
                Id = 2,
                Name = "notIlya",
                Email = "notkusik@jkl.j",
                Login = "User",
                Password = "User",
                
                AuthType = AuthType.Default,
                RoleId = userRole.Id,
                AvatarImageId = 1,
                //LikedPostsId = new List<int>(),
                //PostsId = new List<int>(),
            };

            builder.Entity<Role>().HasData(new Role[] { moderRole, userRole });
            builder.Entity<AvatarImage>().HasData(new AvatarImage[] { avatarImage });
            builder.Entity<User>().HasData(new User[] { moderUser, defailtUser });

            base.OnModelCreating(builder);
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AvatarImage> AvatarImages { get; set; }
        public DbSet<PostContent> PostContents { get; set; }
    }
}
