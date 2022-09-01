using MediatR;
using RG.Application.Common.Models;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderFollowups.Commands.DataTransferModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderFollowups.Commands.Create
{
    public class CreatePlanOrderFollowupCommand : IRequest<RResult>
    {
        public Plan_OrderFollowupDTM Followup { get; set; }
    }
    public class CreatePlanOrderFlowupCommandHandler : IRequestHandler<CreatePlanOrderFollowupCommand, RResult>
    {
        private readonly IPlan_OrderFollowupService plan_OrderFlowupService;

        public CreatePlanOrderFlowupCommandHandler(IPlan_OrderFollowupService _plan_OrderFlowupService)
        {
            plan_OrderFlowupService = _plan_OrderFlowupService;
        }
        public async Task<RResult> Handle(CreatePlanOrderFollowupCommand request, CancellationToken cancellationToken)
        {
            return await plan_OrderFlowupService.Plan_OrderFollowupSave(request.Followup);
        }
    }
}
