using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
using GameBlog.DAL.Enums;
using GameBlog.Models.Models;
using GameBlog.Models.Models.Pagination;
using GameBlog.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.WebApp.Controllers
{
    public class AdController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AdRepository _adRepository;

        public AdController(
            UserManager<User> userManager,
            GameBlogDbContext context
        )
        {
            _userManager = userManager;
            _adRepository = new AdRepository(context);
        }

        [AllowAnonymous]
        [Route("/ad")]
        public async Task<IActionResult> Index(int? page)
        {
            int height = 7;
            int skip = ((page ?? 1) - 1) * height;
            List<AdModel> models = await _adRepository.GetAll();
            GenericPaginatedModel<AdModel> paginatedModel = new GenericPaginatedModel<AdModel>()
            {
                Models = models.Skip(skip).Take(height),
                Pagination = new PaginationModel(models.Count, page ?? 1, height, "Index")
            };
            return View(paginatedModel);
        }

        [HttpGet]
        [Route("/postAd")]
        public async Task<IActionResult> Post()
        {
            var model = new AdViewModel();
            return View(model);
        }
        [HttpPost]
        [Route("/postAd")]
        public async Task<IActionResult> Post(AdViewModel model)
        {
            var ad = _adRepository.Create(
                new Ad()
                {
                    Message = model.Message,
                    CreatorId = (await _userManager.GetUserAsync(User)).Id
                });
            if (ad != null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}