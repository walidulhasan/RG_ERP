namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel
{
    public class MachineMaintenanceNotificationDetailRM
    {
        public string ItemName { get; set; }
        public string MechanicalComments { get; set; }
        public string ElectricalComments { get; set; }
        public int SerialNo { get; set; }
        public string MechanicalWorkerComments { get; set; }
        public string ElectricalWorkerComments { get; set; }
    }
}
