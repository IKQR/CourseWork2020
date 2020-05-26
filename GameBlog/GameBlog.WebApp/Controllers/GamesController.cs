using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
using GameBlog.Models.Models.Pagination;
using GameBlog.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.WebApp.Controllers
{
    public class GameController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GameController(GameBlogDbContext context)
        {
            _gameRepository = new GameRepository(context);
        }
        [HttpGet, Route("/games")]
        public async Task<IActionResult> Index(int? page)
        {
            int height = 15;
            List<GameViewModel> models = await _gameRepository.GetGameViewModels(((page ?? 1) - 1) * height, height);
            GenericPaginatedModel<GameViewModel> paginatedModel = new GenericPaginatedModel<GameViewModel>()
            {
                Models = models,
                Pagination = new PaginationModel(_gameRepository.GetCount(), page ?? 1, height, "Index")
            };
            return View(paginatedModel);
        }
    }
}