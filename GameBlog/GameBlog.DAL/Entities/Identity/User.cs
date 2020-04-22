using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
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

        [DefaultValue(1)]
        public int AvatarImageId { get; set; }
        public AvatarImage AvatarImage { get; set; }
    }
}
