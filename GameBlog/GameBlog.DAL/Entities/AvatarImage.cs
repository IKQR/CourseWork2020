using GameBlog.Models.Enums;

namespace GameBlog.DAL.Entities
{
    public class AvatarImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public ImageType Type { get; set; }
    }
}