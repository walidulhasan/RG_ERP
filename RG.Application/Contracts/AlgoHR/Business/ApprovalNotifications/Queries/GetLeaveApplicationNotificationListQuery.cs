using MediatR;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries
{
    public class GetLeaveApplicationNotificationListQuery : IRequest<List<LeaveApplicationNotificationRM>>
    {
        //public int ApproverEmployeeID { get; set; }
        //public DataSourceLoadOptions LoadOptions { get; set; }
    }
    public class GetLeaveApplicationNotificationListQueryHandler : IRequestHandler<GetLeaveApplicationNotificationListQuery, List<LeaveApplicationNotificationRM>>
    {
        private readonly IApprovalNotificationService approvalNotificationService;

        public GetLeaveApplicationNotificationListQueryHandler(IApprovalNotificationService _approvalNotificationService)
        {
            approvalNotificationService = _approvalNotificationService;
        }
        public async Task<List<LeaveApplicationNotificationRM>> Handle(GetLeaveApplicationNotificationListQuery request, CancellationToken cancellationToken)
        {
            var data = await approvalNotificationService.GetLeaveApplicationNotification(cancellationToken);
            return data;
        }
    }
}
