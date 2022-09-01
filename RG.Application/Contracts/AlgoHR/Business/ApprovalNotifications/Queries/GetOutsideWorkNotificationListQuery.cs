using MediatR;
using RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Queries
{
    public class GetOutsideWorkNotificationListQuery : IRequest<List<OutsideTaskNotificationRM>>
    {
    }
    public class GetOutsideWorkNotificationListQueryHandler : IRequestHandler<GetOutsideWorkNotificationListQuery, List<OutsideTaskNotificationRM>>
    {
        private readonly IApprovalNotificationService approvalNotificationService;

        public GetOutsideWorkNotificationListQueryHandler(IApprovalNotificationService _approvalNotificationService)
        {
            approvalNotificationService = _approvalNotificationService;
        }
        public async Task<List<OutsideTaskNotificationRM>> Handle(GetOutsideWorkNotificationListQuery request, CancellationToken cancellationToken)
        {
            return await approvalNotificationService.GetOutSideTaskNotification(cancellationToken);
        }
    }
}
