using System.Collections.Generic;
using System.Threading.Tasks;
using GameBlog.DAL.Entities;
using GameBlog.Models.ViewModels;

namespace GameBlog.CRUD.Repositories
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task<List<GameViewModel>> GetGameViewModels();
    }
}
