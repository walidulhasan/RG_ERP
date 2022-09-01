using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class CalenderEventMaster:DefaultTableProperties
    {
        public CalenderEventMaster()
        {
            CalenderEventDetail = new List<CalenderEventDetails>();
        }
        public int ID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public virtual List<CalenderEventDetails> CalenderEventDetail { get; set; }
    }
}
