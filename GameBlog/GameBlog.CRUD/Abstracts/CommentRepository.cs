using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models;

namespace GameBlog.CRUD.Abstracts
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(Context context) : base(context)
        {
        }
    }
}
