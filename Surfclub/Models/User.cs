using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Surfclub.Models
{

    public class User
    {
        [Key]
            public int Id { get; set; }
[Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Nickname { get; set; }
        [Required]
        [MaxLength(31)]
       

        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(6)]


            public string Password { get; set; }
        [MaxLength(31)]

            public string LastName { get; set; }
        [MaxLength(31)]
        public string FirstName { get; set; }

            public Guid Photo { get; set; }

        [MaxLength(255)]
        public string Contacts { get; set; }

            public string AboutMe { get; set; }

            public string Achievements { get; set; }
        }


    }

