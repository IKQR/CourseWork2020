using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class PostContentRepository : GenericRepository<PostContent>, IPostContentRepository
    {
        public PostContentRepository(GameBlogDbContext context) : base(context)
        {
        }
    }
}
