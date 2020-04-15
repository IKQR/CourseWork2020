using GameBlog.DAL.Entities;
using GameBlog.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
