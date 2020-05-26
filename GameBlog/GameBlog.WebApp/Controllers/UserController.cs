using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
using GameBlog.Models.Models.Pagination;
using GameBlog.Models.Models.User;
using GameBlog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly PostRepository _postRepository;

        public UserController(UserManager<User> userManager, GameBlogDbContext context)
        {
            _userManager = userManager;
            _postRepository = new PostRepository(context);
        }
        [Route("account")]
        public async Task<IActionResult> Index()
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                UserViewModel model = new UserViewModel()
                {
                    AvatarUrl = Url.Action("get", "image", new { Id = user.AvatarImageId }),
                    Email = user.Email,
                    Name = user.UserName
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return Redirect("Home");
            }
        }

        public async Task<IActionResult> Image()
        {
            //TODO
            return View();
        }
        [HttpGet]
        [Route("changeName")]
        public async Task<IActionResult> Name()
        {
            NameChange model = new NameChange();
            return View(model);
        }
        [HttpPost]
        [Route("changeName")]
        public async Task<IActionResult> Name(NameChange model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.GetUserAsync(User);
                user.UserName = model.Name;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [Route("posts")]
        public async Task<IActionResult> Posts(int? page)
        {
            int size = 15;
            User user = await _userManager.GetUserAsync(User);
            List<PreviewBlogViewModel> models =  
                await _postRepository.GetBlogViewModels((user.PostsId ?? new int[]{}).ToList());
            GenericPaginatedModel<PreviewBlogViewModel> pagiModel = 
                new GenericPaginatedModel<PreviewBlogViewModel>
            {
                Models = models.Skip(size*((page ?? 1)-1)).Take(size),
                Pagination = new PaginationModel(models.Count, page ?? 1, size, "Posts")
            };
            return View(pagiModel);
        }

    }
}