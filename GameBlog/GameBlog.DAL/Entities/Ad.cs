using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameBlog.DAL.Entities
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [MaxLength(128), AllowNull]
        public string Message { get; set; }

        [DefaultValue(false)]
        public bool Permitted { get; set; }
    }
}
