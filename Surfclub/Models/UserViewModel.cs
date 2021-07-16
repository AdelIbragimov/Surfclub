using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surfclub.Models
{
    public class UserViewModel 

    {
        [Required]
        [MaxLength(20)]
        [MinLength(3, ErrorMessage ="Минимальное количество символов 3")]
        [Display(Name = "Псевдоним")]
   public string Nickname { get; set; }
        [Required]
        [MaxLength(31, ErrorMessage ="Такая почта уже зарегистрирована")]

        [Display(Name ="Email")]
        
        public string Email { get; set; }
        [Required]
        [Display(Name ="Пароль")]
        [MaxLength(20)]
        [MinLength(6,ErrorMessage ="Минимальное количество символов 6")]
        public string Password { get; set; }

      [Display(Name = "Подтвердите пароль")]
      [Compare("Password", ErrorMessage ="Пароли не совпадают")]
        public string CheckPassword { get; set; }
        [Display(Name = "Фамилия")]
        [MaxLength(31)]
        public string LastName { get; set; }
        [Display(Name = "Имя")]
        [MaxLength(31)]
        public string FirstName { get; set; }
        [Display(Name = "Фото")]
        public Guid? Photo { get; set; }
        [Display(Name = "Контакты")]
        [MaxLength(255)]
        public string Contacts { get; set; }
        [Display(Name = "О себе")]
        public string AboutMe { get; set; }
        
        [Display(Name = "Достижения")]
        public  string Achievments { get; set; }
     
        public string RequestId { get; internal set; }

       
    }
}
