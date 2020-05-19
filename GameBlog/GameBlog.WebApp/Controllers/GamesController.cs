using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
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
        public IActionResult Index()
        {
            return View();
        }
    }
}