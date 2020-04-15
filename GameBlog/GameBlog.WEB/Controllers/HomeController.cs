using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameBlog.Models;
using GameBlog.CRUD.Abstracts;
using Microsoft.EntityFrameworkCore;
using GameBlog.DAL.Entities;
using GameBlog.Models.Enums;

namespace GameBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public string GameAdd(string name, int id)
        //{
        //    string message = "Everything bad";

        //    GameRepository gameRepository = new GameRepository(_context);
        //    gameRepository.Create(new Game
        //    {
        //        Name = name,
        //        SteamId = id
        //    }
        //    );

        //    return message;
        //}
        //public string UserAdd()
        //{
        //    string message = "Everything bad";
        //    UserRepository userRepository = new UserRepository(_context);
        //    userRepository.Create(new User { 
        //    Login = "User",
        //    Password = "User",
        //    AuthType = AuthType.Default,
        //    RoleId = 1,
        //    Name = "Ilya",
        //    Email = "google.com",
        //    AvatarImageId = 1
        //    });

        //    return message;
        //}
    }
}
