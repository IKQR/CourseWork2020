using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;

namespace GameBlog.DAL.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32), Required]
        public string Title { get; set; }
        [MaxLength(128), Required]
        public string ShortDescription { get; set; }

        [ForeignKey("PostLikeAndView")]
        public int LikeAndViewId { get; set; }
        public PostLikeAndView PostLikeAndView { get; set; }

        [ForeignKey("PostContent")]
        public int PostContentId { get; set; }
        public PostContent PostContent { get; set; }

        [DefaultValue(false)]
        public bool Permitted { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}