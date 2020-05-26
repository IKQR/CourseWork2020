using System;
using System.Collections.Generic;
using System.Text;
using GameBlog.DAL.Entities;

namespace GameBlog.Models.ViewModels
{
    public class PreviewBlogViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }

        public bool Permitted { get; set; }
        public string AuthorName { get; set; }
        public int AuthorAvatarImageId { get; set; }
    }
}
