using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notice.Models
{
    public class aNotice
    {
        public int NoticeID;
        public DateTime DateAndTime_p;
        public DateTime DateAndTime_Expire;
        public DateTime DateAndTime_Show;
        public string Title;
        public string Description;
        public int CategoryID;
        public int AdminID;
        public string CatName;
        public bool HasImage;
        public string Picture;
    }
}
