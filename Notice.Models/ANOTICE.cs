using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notice.Models
{
    public class aNotice
    {
        public int NoticeID { get; set; }
        public DateTime DateAndTime_p { get; set; }
        public DateTime DateAndTime_Expire { get; set; }
        public DateTime DateAndTime_Show { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int AdminID { get; set; }
        public string CatName { get; set; }
        public bool HasImage { get; set; }
        public string Picture { get; set; }
    }
}
