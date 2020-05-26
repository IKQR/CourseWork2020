using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class AdRepository : GenericRepository<Ad>, IAdRepository
    {
        public AdRepository(GameBlogDbContext context) : base(context)
        {
        }

        public async Task<List<AdModel>> GetAll()
        {
            IQueryable<AdModel> models =
                from a in _dbSet
                join u in _context.Set<User>()
                    on a.CreatorId equals u.Id
                    orderby a.Id descending 
                select new AdModel()
                {
                    UserName = u.UserName,
                    Message = a.Message
                };
            return await models.ToListAsync();
        }
    }
}
