using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.AlgoHR.Business
{
    public class CalenderEventFeedback: DefaultTableProperties
    {
        public int ID { get; set; }
        public int EventDetailsID { get; set; }
        public string Comments { get; set; }
    }
}
