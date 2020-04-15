using System.ComponentModel.DataAnnotations;

namespace GameBlog.ua.DAL.Tables
{
    public class PostContent
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
    }
}