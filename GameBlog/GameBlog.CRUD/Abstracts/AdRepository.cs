using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class AdRepository : GenericRepository<Ad>, IAdRepository
    {
        public AdRepository(DbContext context) : base(context)
        {
        }
    }
}
