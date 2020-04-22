using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models;

namespace GameBlog.CRUD.Abstracts
{
    public class AvatarImageRepository : GenericRepository<AvatarImage>, IAvatarImageRepository
    {
        public AvatarImageRepository(GameBlogDbContext context) : base(context)
        {
        }
    }
}
