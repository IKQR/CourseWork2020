using GameBlog.ua.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameBlog.ua.DAL.Tables
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
        public AuthTypes AuthType { get; set; }
        [AllowNull]
        public int[] Posts { get; set; }
        [AllowNull]
        public int[] LikedPosts { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("AvatarImage")]
        public int AvatarImageId { get; set; }
        public AvatarImage AvatarImage { get; set; }
    }
}
