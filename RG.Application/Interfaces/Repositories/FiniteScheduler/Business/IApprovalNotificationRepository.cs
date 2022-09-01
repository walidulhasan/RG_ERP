using RG.Application.Common.Models;
using RG.Application.Contracts.FiniteScheduler.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.DBEntities.FiniteScheduler.Business;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.FiniteScheduler.Business
{
    public interface IApprovalNotificationRepository : IGenericRepository<ApprovalNotification>
    {
        Task<RResult> SaveApprovalNotification(ApprovalNotification entity);
        Task<List<MachineMaintenanceNotificationRM>> GetMachineMaintenanceNotification(int designationID, int employeeID,CancellationToken cancellationToken);
        Task<List<MachineMaintenanceNotificationDetailRM>> GetMachineAndMaintenanceCheckListDetail(int masterID, CancellationToken cancellationToken);
        Task<RResult> UpdateNotification(ApprovalNotification model);
        Task<List<NotificationRM>> GetAllNotifications();
        Task <List<ApprovalNotification>> GetLeaveApplicationNotification(int approverEmployeeID, CancellationToken cancellationToken);

        Task<List<LeaveApplicationsApprovalPendingLevelRM>> GetLeaveApplicationsApprovalPendingLevel(CancellationToken cancellationToken);
    }
}
