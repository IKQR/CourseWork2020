using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameBlog.Models.Models
{
    public class AdModel
    {
        [MaxLength(200)]
        public string Message { get; set; }
        public string UserName { get; set; }
    }
}
