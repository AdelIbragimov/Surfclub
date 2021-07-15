using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surfclub.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Псевдоним")]
        public string Nickname { get; set; }
        [Required]
        [Display(Name ="Пароль")]
        public string Password { get; set; }
        [Display(Name ="Запомнить")]
        public bool RememberMe {get;set;}
    }
}
