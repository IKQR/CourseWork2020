using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameBlog.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [AllowNull]
        public int[] PostsId { get; set; }
        
        [AllowNull]
        public int[] LikedPostsId { get; set; }

        public int AvatarImageId { get; set; }
        public AvatarImage AvatarImage { get; set; }
    }
}
