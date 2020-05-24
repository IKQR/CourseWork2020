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
        private readonly PostLikeAndViewRepository _postLikesAndViewRepository;

        public BlogController(
            UserManager<User> userManager,
            GameBlogDbContext context
            )
        {
            _userManager = userManager;
            _postRepository = new PostRepository(context);
            _postLikesAndViewRepository = new PostLikeAndViewRepository(context);
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
                _postLikesAndViewRepository.Update(new PostLikeAndView
                {
                    Likes = model.Likes,
                    Views = model.Views+1,
                    Id = await _postLikesAndViewRepository.GetIdByPostId(id)
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [Route("/post")]
        public async Task<IActionResult> Post()
        {
            BlogCreationModel model = new BlogCreationModel();
            return View(model);
        }

        [HttpPost]
        [Route("/post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(BlogCreationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                    //some comment
                    //another commit
                }
                var user = await _userManager.GetUserAsync(User);
                Post post = new Post
                {
                    
                    Permitted = true,
                    Title = model.Title,
                    ShortDescription = model.ShortDescription,
                    PostContent = new PostContent
                    {
                        Content = model.Content
                    },
                    UserId = user.Id,
                    PostLikeAndView = new PostLikeAndView()
                };
                post = _postRepository.Create(post);
                if (post != null)
                {
                    List<int> uPosts = user.PostsId == null ? new List<int>() : user.PostsId.ToList();
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
                return View(model);
            }
        }
    }
}