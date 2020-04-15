using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;

namespace GameBlog.ua.DAL.Tables
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32), Required]
        public string Title { get; set; }
        [MaxLength(128), Required]
        public string ShortDescriprion { get; set; }
        [DefaultValue(0), NotNull]
        public int Likes { get; set; }
        [DefaultValue(0), NotNull]
        public int Views { get; set; }
        
        [ForeignKey("PostContent")]
        public int PostContentId { get; set; }
        public PostContent PostContent { get; set; }
        
    }
}