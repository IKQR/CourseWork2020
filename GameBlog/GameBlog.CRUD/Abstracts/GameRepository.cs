using System.Collections.Generic;
using System.Threading.Tasks;
using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using System.Linq;
using GameBlog.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GameBlogDbContext context) : base(context)
        {
        }

        public async Task<List<GameViewModel>> GetGameViewModels()
        {
            IQueryable<GameViewModel> models = 
                (from g in _dbSet
                where g.Permitted == true
                select new GameViewModel()
                {
                    Name = g.Name
                });
            return await models.ToListAsync();
        }
    }
}
