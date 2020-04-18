using GameBlog.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameBlog.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(32), Required]
        public string Login { get; set; }
        [MaxLength(32), Required]
        public string Password { get; set; }
        [MaxLength(32), Required]
        public string Name { get; set; }
        [MaxLength(32), Required]
        public string Email { get; set; }
        [Required]
        public AuthType AuthType { get; set; }
        [AllowNull]
        public int[] PostsId { get; set; }
        [AllowNull]
        public int[] LikedPostsId { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int AvatarImageId { get; set; }
        public AvatarImage AvatarImage { get; set; }
    }
}
