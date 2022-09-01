using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.FiniteScheduler.Business.MT_MachineAndMaintenanceCheckListMasters.Queries.RequestResponseModel
{
    public class MachineAndMaintenanceCheckMasterRM
    {
        public int MasterID { get; set; }
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public int MachineID { get; set; }
        public DateTime? CheckDate { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string MechanicalTaskTeamMember { get; set; }
        public string MechanicalSupervisor { get; set; }
        public string MechanicalWorkerComments { get; set; }
        public string ElectricalTaskTeamMember { get; set; }
        public string ElectricalSupervisor { get; set; }
        public string ElectricalWorkerComments { get; set; }

    }
}
