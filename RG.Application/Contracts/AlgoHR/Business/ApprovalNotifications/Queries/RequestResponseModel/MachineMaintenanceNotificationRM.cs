using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel
{
    public class MachineMaintenanceNotificationRM
    {
        public int NotificationID { get; set; }
        public int ApplicationID { get; set; }
        public int MaintenanceCheckMasterID { get; set; }
        public string MachineName { get; set; }
        public string ScheduleDate { get; set; }
        public string CheckedDate { get; set; }
        public string ElectricalTaskCompletedBy { get; set; }
        public string ElectricalTaskSupervisor { get; set; }
        public string MechanicalTaskCompletedBy { get; set; }
        public string MechanicalTaskSupervisor { get; set; }
        public string FirstAuthorityCommentsDate { get; set; }
        public string LastAuthorityCommentsDate { get; set; }
    }
}
