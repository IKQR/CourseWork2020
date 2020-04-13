using System.ComponentModel.DataAnnotations;

namespace GameBlog.ua.Models.Entities
{
    public class PostContent
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}