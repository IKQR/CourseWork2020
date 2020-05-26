using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameBlog.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(RegexConstants.Email, ErrorMessage = "Invalid Email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression(RegexConstants.Name, ErrorMessage = "Some characters you have used are not allowed")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }

        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
