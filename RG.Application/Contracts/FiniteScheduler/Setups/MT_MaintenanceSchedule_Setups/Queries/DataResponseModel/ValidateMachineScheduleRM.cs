using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries.DataResponseModel
{
   public class ValidateMachineScheduleRM
    {
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public string ScheduleDate { get; set; }
        public string Status { get; set; }
    }
}
