using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GameBlog.Models.Models.User
{
    public class NameChange
    {
        [Required]
        [Display(Name = "Name")]
        [RegularExpression(RegexConstants.Name, ErrorMessage = "Some characters you have used are not allowed")]
        public string Name { get; set; }
    }
}
