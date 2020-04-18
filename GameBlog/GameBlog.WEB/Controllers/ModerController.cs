using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.WEB.Controllers
{
    
    public class ModerController : Controller
    {
        public ModerController()
        {
        }
        [Authorize(Roles = "moder")]
        public IActionResult Index()
        {
            return View();
        }
    }
}