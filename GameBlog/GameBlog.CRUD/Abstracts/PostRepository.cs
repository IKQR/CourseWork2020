using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(GameBlogDbContext context) : base(context)
        {
        }
    }
}
