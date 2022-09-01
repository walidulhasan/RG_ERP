using System;
using System.Collections.Generic;
using System.Text;

namespace RG.DBEntities.FiniteScheduler.Setup
{
    public class MT_Machine_Setup: DefaultTableProperties
    {
        public int MachineID { get; set; }
        public int MachineGroupID { get; set; }
        public string MachineName { get; set; }
        public string MachineCode { get; set; }
        public int LocationID { get; set; }
        public int? DepartmentID { get; set; }
        public DateTime? CheckedDate { get; set; }
        public DateTime? NextCheckDate { get; set; }
        public int? MinMaintainceDurationDays { get; set; }
         
    }
}
