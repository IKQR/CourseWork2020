using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
using GameBlog.Models.Models.Blog;
using GameBlog.Models.Models.Pagination;
using GameBlog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.WebApp.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly PostRepository _postRepository;

        public BlogController(
            UserManager<User> userManager,
            GameBlogDbContext context
            )
        {
            _userManager = userManager;
            _postRepository = new PostRepository(context);
        }

        [AllowAnonymous]
        [Route("/blog")]
        public async Task<IActionResult> Index(int? page)
        {
            int height = 1;
            int skip = ((page ?? 1) - 1) * height;
            List<PreviewBlogViewModel> models = await _postRepository.GetBlogViewModels();
            GenericPaginatedModel<PreviewBlogViewModel> paginatedModel = new GenericPaginatedModel<PreviewBlogViewModel>()
            {
                Models = models.Skip(skip).Take(height),
                Pagination = new PaginationModel(models.Count, page ?? 1, height, "Index")
            };
            return View(paginatedModel);
        }

        [AllowAnonymous]
        [Route("/blog/{id:int}")]
        public async Task<IActionResult> Item(int id)
        {
            BlogViewModel model = await _postRepository.GetById(id);
            if (model == null || !model.Permitted)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("/post")]
        public async Task<IActionResult> Create()
        {
            BlogCreationModel model = new BlogCreationModel();
            return View(model);
        }

        [HttpPost]
        [Route("/post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var user = await _userManager.GetUserAsync(User);
                Post post = new Post
                {
                    Likes = 0,
                    Views = 0,
                    Permitted = true,
                    Title = model.Title,
                    ShortDescriprion = model.ShortDescription,
                    PostContent = new PostContent
                    {
                        Content = model.Content
                    },
                    UserId = user.Id
                };
                post = _postRepository.Create(post);
                if (post != null)
                {
                    List<int> uPosts = user.PostsId.ToList();
                    uPosts.Add(post.Id);
                    user.PostsId = uPosts.ToArray();
                    await _userManager.UpdateAsync(user);
                    return RedirectToAction("Item", new { id = post.Id });
                }
                return View(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}