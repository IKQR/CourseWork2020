using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace GameBlog.Models.ViewModels
{

    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]

        [RegularExpression(RegexConstants.Email, ErrorMessage = "Invalid Email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }

}
