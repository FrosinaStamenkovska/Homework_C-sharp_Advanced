using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Models.Enums;

namespace TimeTracking.Models
{
    public class Reading: Activity
    {
        public int Pages { get; set; }
        public ReadingTypeEnum ReadingType { get; set; }
        
        public Reading()
        {
            Pages = 0;
        }
    }
}
