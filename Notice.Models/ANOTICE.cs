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
      
      
      
        public DateTime? DateAndTime_p { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd HH:MM}")]
        public DateTime? DateAndTime_Expire { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd HH:MM}")]
        public DateTime? DateAndTime_Show { get; set; }

        [Required]
        public string Title { get; set; }
        
        [Required]
      
        public string Description { get; set; }
       
        public int CategoryID { get; set; }
       
        public int AdminID { get; set; }
        
        public string CatName { get; set; }
       
    }
}
