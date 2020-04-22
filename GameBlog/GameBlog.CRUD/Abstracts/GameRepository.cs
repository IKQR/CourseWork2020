using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        public GameRepository(GameBlogDbContext context) : base(context)
        {
        }
    }
}
