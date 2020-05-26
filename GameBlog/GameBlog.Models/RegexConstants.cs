using System;
using System.Collections.Generic;
using System.Text;

namespace GameBlog.Models
{
    public class RegexConstants
    {
        public const string Email = @"[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}";
        public const string Name = @"^[a-zA-Z''_''-'\s]{1,40}$";
    }
}