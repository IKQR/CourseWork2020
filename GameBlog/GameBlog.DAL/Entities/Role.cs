using System.ComponentModel.DataAnnotations;

namespace GameBlog.DAL.Entities
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