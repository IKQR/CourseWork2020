using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameBlog.CRUD.Repositories;
using GameBlog.DAL.Entities;
using GameBlog.DAL.Enums;
using GameBlog.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.CRUD.Abstracts
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(GameBlogDbContext context) : base(context)
        {
        }

        public async Task<BlogViewModel> GetById(int id)
        {
            IQueryable<BlogViewModel> models =
                (from p in _dbSet
                    join u in _context.Set<User>()
                        on p.UserId equals u.Id
                 join c in _context.Set<PostContent>()
                     on p.PostContentId equals c.Id
                     join lav in _context.Set<PostLikeAndView>()
                         on p.PostLikeAndView.Id equals lav.Id
                 where p.Id == id
                 select new BlogViewModel()
                 {
                     Id = p.Id,
                     Title = p.Title,
                     ShortDescription = p.ShortDescription,
                     Permitted = p.Permitted,
                     Likes = lav.Likes,
                     Views = lav.Views,
                     Content = c.Content,
                     AuthorName = u.UserName,
                     AuthorAvatarImageId = u.AvatarImageId
                 });
            return await models.FirstOrDefaultAsync();
        }
        public async Task<List<PreviewBlogViewModel>> GetBlogViewModels()
        {
            IQueryable<PreviewBlogViewModel> models =
                (from p in _dbSet
                    join u in _context.Set<User>() 
                        on p.UserId equals u.Id
                    join lav in _context.Set<PostLikeAndView>()
                        on p.PostLikeAndView.Id equals lav.Id
                 select new PreviewBlogViewModel()
                 {
                     Id = p.Id,
                     Title = p.Title,
                     ShortDescription = p.ShortDescription,
                     Permitted = p.Permitted,
                     Likes = lav.Likes,
                     Views = lav.Views,
                     AuthorName = u.UserName,
                     AuthorAvatarImageId = u.AvatarImageId
                 });
            return await models.ToListAsync();
        }
        public async Task<List<PreviewBlogViewModel>> GetBlogViewModels(PostType type)
        {
            IQueryable<PreviewBlogViewModel> models =
                (from p in _dbSet
                    join u in _context.Set<User>() 
                        on p.UserId equals u.Id
                    join lav in _context.Set<PostLikeAndView>()
                        on p.PostLikeAndView.Id equals lav.Id
                    where p.Type == type
                 select new PreviewBlogViewModel()
                 {
                     Id = p.Id,
                     Title = p.Title,
                     ShortDescription = p.ShortDescription,
                     Permitted = p.Permitted,
                     Likes = lav.Likes,
                     Views = lav.Views,
                     AuthorName = u.UserName,
                     AuthorAvatarImageId = u.AvatarImageId
                 });
            return await models.ToListAsync();
        }
        public async Task<List<PreviewBlogViewModel>> GetBlogViewModels(int skip, int take)
        {
            var models =
                (from p in _dbSet
                    join u in _context.Set<User>()
                        on p.UserId equals u.Id
                    join lav in _context.Set<PostLikeAndView>()
                        on p.PostLikeAndView.Id equals lav.Id
                 select new PreviewBlogViewModel()
                 {
                     Id = p.Id,
                     Title = p.Title,
                     ShortDescription = p.ShortDescription,
                     Permitted = p.Permitted,
                     Likes = lav.Likes,
                     Views = lav.Views,
                     AuthorName = u.UserName,
                     AuthorAvatarImageId = u.AvatarImageId
                 });
            return await models.Skip(skip).Take(take).ToListAsync();
        }
    }
}
