using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(DbContext context) : base(context)
        {
        }
    }
}
