using System.Threading.Tasks;
using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class PostLikeAndViewRepository : GenericRepository<PostLikeAndView>, IPostLikeAndViewRepository
    {
        public PostLikeAndViewRepository(GameBlogDbContext context) : base(context)
        {
        }

        public async Task<int> GetIdByPostId(int id)
        {
            IQueryable<PostLikeAndView> rezult =
                (from lav in _dbSet
                join post in _context.Set<Post>()
                    on lav.Id equals post.LikeAndViewId
                where post.Id == id
                select new PostLikeAndView()
                {
                    Id = lav.Id
                });

            return (await rezult.FirstOrDefaultAsync()).Id;
        }
    }
}
