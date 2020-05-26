using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;

namespace GameBlog.CRUD.Abstracts
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(GameBlogDbContext context) : base(context)
        {
        }
    }
}
