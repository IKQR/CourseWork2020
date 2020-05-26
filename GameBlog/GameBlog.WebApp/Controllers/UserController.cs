using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
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
        public async Task<IActionResult> Name()
        {
            NameChange model = new NameChange();
            return View(model);
        }
        [HttpPost]
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
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Posts()
        {
            return View();
        }
    }
}