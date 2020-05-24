using System.Collections.Generic;
using System.Threading.Tasks;
using GameBlog.DAL.Entities;
using GameBlog.Models.ViewModels;

namespace GameBlog.CRUD.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        public Task<BlogViewModel> GetById(int id);
        public Task<List<PreviewBlogViewModel>> GetBlogViewModels();
        public Task<List<PreviewBlogViewModel>> GetBlogViewModels(int skip, int take);
    }
}
