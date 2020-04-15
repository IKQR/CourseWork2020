using System.ComponentModel.DataAnnotations;

namespace GameBlog.DAL.Entities
{
    public class PostContent
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}