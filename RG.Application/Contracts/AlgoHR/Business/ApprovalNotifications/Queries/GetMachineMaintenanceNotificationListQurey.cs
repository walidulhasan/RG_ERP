using MediatR;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries
{
    public class GetMachineMaintenanceNotificationListQurey : IRequest<List<MachineMaintenanceNotificationRM>>
    {
        public int DesignationID { get; set; }
        public int EmployeeID { get; set; }
    }
    public class GetMachineMaintenanceNotificationListQureyHandler : IRequestHandler<GetMachineMaintenanceNotificationListQurey, List<MachineMaintenanceNotificationRM>>
    {
        private readonly IApprovalNotificationService approvalNotificationService;

        public GetMachineMaintenanceNotificationListQureyHandler(IApprovalNotificationService _approvalNotificationService)
        {
            approvalNotificationService = _approvalNotificationService;
        }
        public async Task<List<MachineMaintenanceNotificationRM>> Handle(GetMachineMaintenanceNotificationListQurey request, CancellationToken cancellationToken)
        {
            return await approvalNotificationService.GetMachineMaintenanceNotification(request.DesignationID, request.EmployeeID, cancellationToken);
        }
    }
}
