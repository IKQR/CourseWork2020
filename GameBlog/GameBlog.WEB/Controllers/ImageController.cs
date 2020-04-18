using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameBlog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.WEB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private Context _context;
        public ImageController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(int id = 1)
        {
            var image = _context.AvatarImages.FirstOrDefault(a => a.Id == id);
            if (image != null)
                return File(image.Image, $"image/{image.Type.ToString()}");
            return File(new byte[] { }, "image/jpeg");
        }
    }
}
