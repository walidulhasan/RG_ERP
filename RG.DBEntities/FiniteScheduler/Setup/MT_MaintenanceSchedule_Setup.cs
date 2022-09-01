using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class MT_MaintenanceSchedule_Setup : DefaultTableProperties
    {
        public int ID { get; set; }
        public int MachineID { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? CheckedStatus { get; set; }
    }
}
