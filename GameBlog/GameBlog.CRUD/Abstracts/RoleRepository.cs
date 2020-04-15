using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }
    }
}
