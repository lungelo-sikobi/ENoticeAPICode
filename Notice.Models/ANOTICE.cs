using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notice.Models
{
    public class aNotice
    {
        public int NoticeID { get; set; }
        [Required]
        public DateTime DateAndTime_p { get; set; }
        [Required]
        public DateTime DateAndTime_Expire { get; set; }
        [Required]
        public DateTime DateAndTime_Show { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int CategoryID { get; set; }
       
        public int AdminID { get; set; }
        [Required]
        public string CatName { get; set; }
     
        public bool HasImage { get; set; }
        public string Picture { get; set; }
    }
}
