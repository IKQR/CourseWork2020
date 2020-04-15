using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }
    }
}
