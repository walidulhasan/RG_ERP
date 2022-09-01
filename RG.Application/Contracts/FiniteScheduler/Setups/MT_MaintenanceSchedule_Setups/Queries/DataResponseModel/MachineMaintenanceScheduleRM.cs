using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Setups.MT_MaintenanceSchedule_Setups.Queries.DataResponseModel
{
    public class MachineMaintenanceScheduleRM
    {
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string ScheduleDateMsg { get { return ScheduleDate.ToString("dd-MMM-yyyy"); } }
        public DateTime? CheckDate { get; set; }
        public string CheckDateMsg { get { return CheckDate==null?"": CheckDate.Value.ToString("dd-MMM-yyyy"); } }
        public int DayDifference { get; set; }
        public string MechanicalWorkerComments { get; set; }
        public string ElectricalWorkerComments { get; set; }
        public string MechanicalTaskCompletedBy { get; set; }
        public string ElectricalTaskCompletedBy { get; set; }
        public string MechanicalTaskSupervisor { get; set; }
        public string ElectricalTaskSupervisor { get; set; }
        public string FirstApproval { get; set; }
        public string LastApproval { get; set; }
    }
}
