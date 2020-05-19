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
        public static async Task InitializeAsync(AvatarImageRepository repo)
        {
            var idCounter = 0;
            var images = new string[] { @"C:\Users\Ilya\Documents\KPI\OP\CourseWork2020\GameBlog\GameBlog.DAL\avatar.png" };

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
