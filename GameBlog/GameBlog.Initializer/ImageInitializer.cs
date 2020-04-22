using GameBlog.CRUD.Abstracts;
using GameBlog.DAL.Entities;
using GameBlog.Models.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace GameBlog.Initializer
{
    public class ImageInitializer
    {
        public static async Task InitializeAsync(GameBlogDbContext context)
        {
            var repo = new AvatarImageRepository(context);
            var idCounter = 0;
            var images = new string[] { "Images/avatar.png" };

            //try
            //{
            //    images = Directory.GetFiles("Images");
            //}
            //catch(Exception ex)
            //{
                
            //}

            foreach (var img in images)
            {
                if (repo.FindById(++idCounter) == null)
                {
                    repo.Create(new AvatarImage
                    {
                        Id = idCounter,
                        Image = System.IO.File.ReadAllBytes(img),
                        Type = ImageType.PNG
                    });
                }
            }
        }
    }
}
