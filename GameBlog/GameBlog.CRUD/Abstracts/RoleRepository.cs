using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(GameBlogDbContext context) : base(context)
        {
        }
    }
}
