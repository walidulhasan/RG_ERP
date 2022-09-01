namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel
{
    public class NotificationRM
    {
        public int NotificationCount { get; set; }
        public string NotificationType { get; set; }
        public string NotificationGroup { get; set; }
        public string ApprovalURL { get; set; }
    }
}
