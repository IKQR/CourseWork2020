using System.Collections.Generic;
namespace GameBlog.Models.ViewModels
{
    public class BlogViewModel : PreviewBlogViewModel
    {
        public bool isLiked { get; set; }
        public string Content { get; set; }
        public List<CommentModel> Comments { get; set; }
        public string Comment { get; set; }
    }

    public class CommentModel
    {
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public int AuthorAvatarId { get; set; }
    }
}
