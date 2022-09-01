using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel
{
    public class MachineMaintainceItemDetailRM
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int MachineGroupID { get; set; }
        public string MachineGroup { get; set; }
        public int MachineID { get; set; }
        public string MachineName { get; set; }
        public string MachineCode { get; set; }
        public DateTime? LastCheckDate { get; set; }
        public DateTime? NextCheckDate { get; set; }
        public int? MinMaintainceDurationDays { get; set; }
        public string ItemName { get; set; }
        public string ItemNameShort { get; set; }
        public int MT_MachineAndMaintenanceCheckListMasterID { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? CheckDayDifference { get; set; }
        public string FirstAuthorityComments { get; set; }
        public string LastAuthorityComments { get; set; }
        public DateTime LastAuthorityCommentsDate { get; set; }
        public int MT_MachineAndMaintenanceCheckListDetailsID { get; set; }
        public string MechanicalComments { get; set; }
        public string ElectricalComments { get; set; }
        public int SerialNo { get; set; }
        public bool MechanicalChecked { get; set; }
        public bool ElectricalChecked { get; set; }
        public string MechanicalTaskSupervisor { get; set; }
        public string ElectricalTaskSupervisor { get; set; }
        public string MechanicalWorkerComments { get; set; }
        public string ElectricalWorkerComments { get; set; }
        public string MechanicalTaskCompletedBy { get; set; }
        public string ElectricalTaskCompletedBy { get; set; }
        
    }
}
