using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using GameBlog.DAL.Enums;

namespace GameBlog.Models.Models.Blog
{
    public class BlogCreationModel
    {
        [Required]
        [Display(Name = "Type of post")]
        public PostType Type { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
        [AllowNull]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
    }
}
