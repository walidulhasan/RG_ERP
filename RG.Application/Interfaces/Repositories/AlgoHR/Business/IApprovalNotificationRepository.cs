using RG.Application.Common.Models;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.DBEntities.AlgoHR.Business;
using RG.DBEntities.AlgoHR.DBViews;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.AlgoHR.Business
{
    public interface IApprovalNotificationRepository : IGenericRepository<ApprovalNotification>
    {
        Task<RResult> SaveApprovalNotification(ApprovalNotification entity);
        Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceNotification(int designationID, int employeeID, CancellationToken cancellationToken);

        Task<RResult> UpdateNotification(ApprovalNotification model);
        Task<List<NotificationRM>> GetAllNotifications();
        Task<List<ApprovalNotification>> GetLeaveApplicationNotification(int approverEmployeeID, CancellationToken cancellationToken);
        Task<List<LeaveApplicationsApprovalPendingLevelRM>> GetLeaveApplicationsApprovalPendingLevel(CancellationToken cancellationToken);
        Task<List<OutsideTaskNotificationRM>> GetOutSideTaskNotification(int approverEmployeeID, int caUserID, CancellationToken cancellationToken);

    }
}
