using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class PostContentRepository : GenericRepository<PostContent>, IPostContentRepository
    {
        public PostContentRepository(DbContext context) : base(context)
        {
        }
    }
}
