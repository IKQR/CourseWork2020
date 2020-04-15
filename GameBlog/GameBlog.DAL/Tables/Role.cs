using System.ComponentModel.DataAnnotations;

namespace GameBlog.ua.DAL.Tables
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32), Required]
        public string Name { get; set; }
        [MaxLength(128), Required]
        public string Description { get; set; }
    }
}