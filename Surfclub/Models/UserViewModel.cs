using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surfclub.Models
{
    public class UserViewModel : User

    {
        [Display(Name="")]
        public string CheckPassword { get; set; }
    }
}
