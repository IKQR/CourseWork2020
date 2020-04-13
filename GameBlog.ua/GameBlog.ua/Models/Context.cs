using GameBlog.ua.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.ua.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<AvatarImage> AvatarImages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostContent> PostContents { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
