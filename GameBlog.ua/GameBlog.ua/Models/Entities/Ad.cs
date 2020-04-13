using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GameBlog.ua.Models.Entities
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [MaxLength(128), AllowNull]
        public string Message { get; set; }
    }
}
