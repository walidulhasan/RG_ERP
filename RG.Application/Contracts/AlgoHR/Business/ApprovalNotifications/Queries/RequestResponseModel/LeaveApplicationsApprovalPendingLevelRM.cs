namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel
{
    public class LeaveApplicationsApprovalPendingLevelRM
    {
        public int NotificationID { get; set; }
        public int ApplicationID { get; set; }
        public int ApprovalMasterID { get; set; }
        public int ApprovalDetailID { get; set; }
        public int ApproverEmployeeID { get; set; }
        public string ApproverEmployeeCode { get; set; }
        public string ApproverEmployeeName { get; set; }
    }
}
