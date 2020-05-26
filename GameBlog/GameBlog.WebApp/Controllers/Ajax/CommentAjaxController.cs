using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
using GameBlog.Models.Models.Blog;
using GameBlog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.WebApp.Controllers.Ajax
{
    [Authorize]
    public class CommentAjaxController : Controller
    {
        private readonly PostLikeAndViewRepository _lavRepository;
        private readonly CommentRepository _commentsRepository;
        private readonly PostRepository _postRepository;
        private readonly UserManager<User> _userManager;

        public CommentAjaxController(GameBlogDbContext context, UserManager<User> userManager)
        {
            _commentsRepository = new CommentRepository(context);
            _postRepository = new PostRepository(context);
            _lavRepository = new PostLikeAndViewRepository(context);
            _userManager = userManager;
        }
        [HttpPost]
        [Route("comm")]
        public async Task<IActionResult> PostComments(CommentCreationModel model)
        {
            BlogViewModel mod = await _postRepository.GetById(model.PostId);
            if (mod != null && model.Comment.Trim() != "")
                _commentsRepository.Create(new Comment()
                {
                    PostId = model.PostId,
                    UserId = (await _userManager.GetUserAsync(User)).Id,
                    Content = model.Comment
                });
            return RedirectToAction("Item", "Blog", new { id = model.PostId, view = false });
        }
        [HttpPost]
        [Route("like")]
        public async Task<IActionResult> AddLike(int postId)
        {
            Post post = _postRepository.Get(p => p.Id == postId).FirstOrDefault();
            if (post != null)
            {
                PostLikeAndView lav = _lavRepository.Get(p => p.Id == post.LikeAndViewId).FirstOrDefault();
                User user = await _userManager.GetUserAsync(User);
                List<int> ulp = (user.LikedPostsId ?? new int[]{}).ToList();
                if (ulp.Contains(postId))
                {
                    lav.Likes--;
                    ulp.Remove(postId);
                }
                else
                {
                    lav.Likes++;
                    ulp.Add(postId);
                }
                _lavRepository.Update(lav);
                user.LikedPostsId = ulp.ToArray();
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Item", "Blog", new { id = postId, view = false });
        }
    }
}
