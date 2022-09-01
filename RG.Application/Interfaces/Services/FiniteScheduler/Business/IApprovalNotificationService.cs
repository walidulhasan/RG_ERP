using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.ApprovalNotifications.Queries.RequestResponseModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Services.FiniteScheduler.Business
{
    public interface IApprovalNotificationService
    {
        Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceNotification(int designationID, int employeeID, CancellationToken cancellationToken);
        Task<List<LeaveApplicationNotificationRM>> GetLeaveApplicationNotification( CancellationToken cancellationToken);
        
        Task<List<MachineMaintenanceNotificationDetailRM>> GetMachineAndMaintenanceCheckListDetail(int masterID, CancellationToken cancellationToken);
        Task<RResult> ApproveNotification(List<int> notificationIDs, string comment);
        Task<RResult> RejectNotification(int notificationID, string comment);
        Task<List<NotificationRM>> GetAllNotifications();
        Task<List<LeaveApplicationsApprovalPendingLevelRM>> GetLeaveApplicationsApprovalPendingLevel(CancellationToken cancellationToken);
    }
}

