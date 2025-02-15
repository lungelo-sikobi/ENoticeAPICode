﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notice.Models
{
    public class Admin
    {

        public int  AdminID { get; set; }

        [Required]
        [StringLength(20)]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter letters")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please enter letters")]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$
      
        [Required]
         public string Password { get; set; }

        [Required]
        public string DepartID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public bool LoggedOnce { get; set; }

        public bool SuperAdmin { get; set; }
    }
}
