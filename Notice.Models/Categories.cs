using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notice.Models
{
    public class Categories
    {
        public int ID { get; set; }
        [Required]
       
        [Display(Name = "Category name")]
        public string Name { get; set; }
        [Required]
       
        public string description { get; set; }
    }
}
