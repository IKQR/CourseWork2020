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

        public int GetCount()
        {
            var games =
                from g in _dbSet
                where g.Permitted == true &&
                      !g.Name.ToUpper().Contains("SERVER") &&
                      !g.Name.ToUpper().Contains("OST") &&
                      !g.Name.ToUpper().Contains("DLC") &&
                      !g.Name.ToUpper().Contains("TEST") &&
                      !g.Name.ToUpper().Contains("SOUNDTRACK") &&
                      !g.Name.ToUpper().Contains("DEMO") &&
                      !g.Name.ToUpper().Contains("KEY") &&
                      !g.Name.ToUpper().Contains("NONE") &&
                      !g.Name.ToUpper().Contains("PACK") &&
                      !g.Name.ToUpper().Contains("TRAILER") &&
                      !g.Name.ToUpper().Contains("3DMARK") &&
                      !g.Name.ToUpper().Contains("_") &&
                      !g.Name.ToUpper().Contains("'")
                select new Game();
            return games.Count();
        }

        public async Task<List<GameViewModel>> GetGameViewModels()
        {
            IQueryable<GameViewModel> models =
                (from g in _dbSet
                 orderby g.Name
                 where g.Permitted == true &&
                     !g.Name.ToUpper().Contains("SERVER") &&
                     !g.Name.ToUpper().Contains("OST") &&
                     !g.Name.ToUpper().Contains("DLC") &&
                     !g.Name.ToUpper().Contains("TEST") &&
                     !g.Name.ToUpper().Contains("SOUNDTRACK") &&
                     !g.Name.ToUpper().Contains("DEMO") &&
                     !g.Name.ToUpper().Contains("KEY") &&
                     !g.Name.ToUpper().Contains("NONE") &&
                     !g.Name.ToUpper().Contains("PACK") &&
                     !g.Name.ToUpper().Contains("TRAILER") &&
                     !g.Name.ToUpper().Contains("3DMARK") &&
                     !g.Name.ToUpper().Contains("_") &&
                     !g.Name.ToUpper().Contains("'")

                 select new GameViewModel()
                 {
                     SteamId = g.SteamId,
                     Name = g.Name
                 });
            return await models.ToListAsync();
        }
        public async Task<List<GameViewModel>> GetGameViewModels(int skip, int take)
        {
            IQueryable<GameViewModel> models =
                (from g in _dbSet
                 orderby g.Name
                 where g.Permitted == true &&
                       !g.Name.ToUpper().Contains("SERVER") &&
                       !g.Name.ToUpper().Contains("OST") &&
                       !g.Name.ToUpper().Contains("DLC") &&
                       !g.Name.ToUpper().Contains("TEST") &&
                       !g.Name.ToUpper().Contains("SOUNDTRACK") &&
                       !g.Name.ToUpper().Contains("DEMO") &&
                       !g.Name.ToUpper().Contains("KEY") &&
                       !g.Name.ToUpper().Contains("NONE") &&
                       !g.Name.ToUpper().Contains("PACK") &&
                       !g.Name.ToUpper().Contains("TRAILER") &&
                       !g.Name.ToUpper().Contains("3DMARK") &&
                       !g.Name.ToUpper().Contains("_") &&
                       !g.Name.ToUpper().Contains("'")
                 select new GameViewModel()
                 {
                     SteamId = g.SteamId,
                     Name = g.Name
                 });
            return await models.Skip(skip).Take(take).ToListAsync();
        }
    }
}
