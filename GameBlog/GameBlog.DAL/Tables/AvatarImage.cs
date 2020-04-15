using GameBlog.ua.Models.Enums;

namespace GameBlog.ua.DAL.Tables
{
    public class AvatarImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public ImageType Type { get; set; }
    }
}