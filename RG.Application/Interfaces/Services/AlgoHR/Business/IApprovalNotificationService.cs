using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.DBViews;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.AlgoHR.Business
{
    public interface IApprovalNotificationService
    {
        Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceNotification(int designationID, int employeeID, CancellationToken cancellationToken);
        Task<List<LeaveApplicationNotificationRM>> GetLeaveApplicationNotification(CancellationToken cancellationToken);    
        Task<RResult> ApproveNotification(List<int> notificationIDs, string comment);
        Task<RResult> RejectNotification(int notificationID, string comment);
        Task<List<NotificationRM>> GetAllNotifications();
        Task<List<LeaveApplicationsApprovalPendingLevelRM>> GetLeaveApplicationsApprovalPendingLevel(CancellationToken cancellationToken);
        Task<List<OutsideTaskNotificationRM>> GetOutSideTaskNotification(CancellationToken cancellationToken);
        Task<RResult> ApprovalNotificationCancel(int applicationID,string Comment,string status,string ModuleName, bool saveChanges = true);
    }
}
