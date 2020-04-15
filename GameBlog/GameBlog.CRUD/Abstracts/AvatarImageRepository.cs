using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class AvatarImageRepository : GenericRepository<AvatarImage>, IAvatarImageRepository
    {
        public AvatarImageRepository(DbContext context) : base(context)
        {
        }
    }
}
