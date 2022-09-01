using MediatR;
using RG.Application.Common.Models;
using RG.Application.Common.Security;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Commands.Update
{
    //[CheckAuthorize(Policy = "Permission_FiniteScheduler_Notification_Approve")]
    public class ApproveNotificationCommand : IRequest<RResult>
    {
        public List<int> NotificationIDs { get; set; }
        public string Comment { get; set; }
    }
    public class ApproveNotificationCommandHandler : IRequestHandler<ApproveNotificationCommand, RResult>
    {
        private readonly IApprovalNotificationService approvalNotificationService;

        public ApproveNotificationCommandHandler(IApprovalNotificationService _approvalNotificationService)
        {
            approvalNotificationService = _approvalNotificationService;
        }
        public async Task<RResult> Handle(ApproveNotificationCommand request, CancellationToken cancellationToken)
        {
            return await approvalNotificationService.ApproveNotification(request.NotificationIDs, request.Comment);
        }
    }
}
