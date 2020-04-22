using GameBlog.DAL.Entities;
using GameBlog.Models.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;

namespace GameBlog.DAL.Entities
{
    public class GameBlogDbContext : IdentityDbContext<User, Role, int>
    {
        public GameBlogDbContext(DbContextOptions<GameBlogDbContext> options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<ImageType>(
                "ImageType",
                new Npgsql.NameTranslation.NpgsqlNullNameTranslator()
            );
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.ForNpgsqlHasEnum(typeof(ImageType).Name, typeof(ImageType).GetEnumNames());

            AvatarImage avatarImage = new AvatarImage { 
                Id = 1, 
                Image = System.IO.File.ReadAllBytes(@"C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.DAL\avatar.png"), 
                Type = ImageType.PNG };
            builder.Entity<AvatarImage>().HasData(new AvatarImage[] { avatarImage });
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<AvatarImage> AvatarImages { get; set; }
        public DbSet<PostContent> PostContents { get; set; }
        public DbSet<IdentityUserClaim<int>> IdentityUserClaim { get; set; }
    }
}
