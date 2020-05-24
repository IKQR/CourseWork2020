using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace GameBlog.DAL.Entities
{
    public class PostLikeAndView
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue(0), NotNull]
        public int Likes { get; set; }

        [DefaultValue(0), NotNull]
        public int Views { get; set; }
    }
}
