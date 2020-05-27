using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(GameBlogDbContext context) : base(context)
        {
        }

        public async Task<User> GetByMail(string email)
        {
            IQueryable<User> user =
                from u in _dbSet
                where u.NormalizedEmail == email.ToUpper()
                select new User()
                {
                    Email = u.Email,
                    UserName = u.UserName
                };
            return await user.FirstOrDefaultAsync();
        }
    }
}
