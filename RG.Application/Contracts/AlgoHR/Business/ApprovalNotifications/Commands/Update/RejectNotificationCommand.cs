using MediatR;
using RG.Application.Common.Models;
using RG.Application.Interfaces.Services.AlgoHR.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.AlgoHR.Business.ApprovalNotifications.Commands.Update
{
    public class RejectNotificationCommand : IRequest<RResult>
    {
        public int NotificationID { get; set; }
        public string Comment { get; set; }
    }
    public class RejectNotificationCommandHandler : IRequestHandler<RejectNotificationCommand, RResult>
    {
        private readonly IApprovalNotificationService approvalNotificationService;

        public RejectNotificationCommandHandler(IApprovalNotificationService _approvalNotificationService)
        {
            approvalNotificationService = _approvalNotificationService;
        }
        public async Task<RResult> Handle(RejectNotificationCommand request, CancellationToken cancellationToken)
        {
            return await approvalNotificationService.RejectNotification(request.NotificationID, request.Comment);
        }
    }
}
