using System;
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
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string Password { get; set; }
        [Required]
        public string DepartID { get; set; }
        [Required]
        [MinLength(10)]
        public string Cellphone { get; set; }

    }
}
