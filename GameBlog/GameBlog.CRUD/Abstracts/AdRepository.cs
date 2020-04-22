using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class AdRepository : GenericRepository<Ad>, IAdRepository
    {
        public AdRepository(GameBlogDbContext context) : base(context)
        {
        }
    }
}
