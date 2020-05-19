using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
using GameBlog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace GameBlog.WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                User user = await _userManager.GetUserAsync(User);
                UserViewModel model = new UserViewModel()
                {
                    AvatarUrl = Url.Action("get", "image", new {Id = user.AvatarImageId}),
                    Email = user.Email,
                    Name = user.UserName
                };
                return View(model);
            }
            catch(Exception ex)
            {
                return Redirect("Home");
            }
        }

        public async Task<IActionResult> Image()
        {
            //TODO
            return View();
        }
        public async Task<IActionResult> Name()
        {
            //TODO
            return View();
        }
    }
}