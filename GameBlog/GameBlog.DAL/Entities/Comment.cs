using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameBlog.DAL.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Content { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
