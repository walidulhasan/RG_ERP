using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public class MT_MachineAndMaintenanceCheckListMaster: DefaultTableProperties
    {
        public int ID { get; set; }
        public int MachineID { get; set; }
        public int ScheduleID { get; set; }   
        public int? StatusID { get; set; }
        public DateTime? StatusDate { get; set; }
        public string MechanicalTaskCompletedBy { get; set; }
        public string MechanicalTaskSupervisor { get; set; }
        public string MechanicalWorkerComments { get; set; }
        public string ElectricalTaskCompletedBy { get; set; }
        public string ElectricalTaskSupervisor { get; set; }
        public string ElectricalWorkerComments { get; set; }
        public string FirstAuthorityComments { get; set; }
        public DateTime? FirstAuthorityCommentsDate { get; set; }
        public string LastAuthorityComments { get; set; }
        public DateTime? LastAuthorityCommentsDate { get; set; }
        public virtual List<MT_MachineAndMaintenanceCheckListDetails> MachineAndMaintenanceCheckListDetails { get; set; }

    }
}
