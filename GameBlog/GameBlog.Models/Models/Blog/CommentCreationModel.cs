using System;
using System.Collections.Generic;
using System.Text;

namespace GameBlog.Models.Models.Blog
{
    public class CommentCreationModel
    {
        public int PostId { get; set; }
        public string Comment { get; set; }
    }
}
