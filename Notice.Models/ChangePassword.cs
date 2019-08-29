using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Notice.Models
{
     public class ChangePassword
    {
        public int AdminID { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }


        [RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=]).*$", ErrorMessage = "your password should contain one special character, one uppercase, one lowercase(in any order) and be 8 characters long")]
        [DataType(DataType.Password)]
        [Required (ErrorMessage = "This field is required.")]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Re-type Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

    }
}
