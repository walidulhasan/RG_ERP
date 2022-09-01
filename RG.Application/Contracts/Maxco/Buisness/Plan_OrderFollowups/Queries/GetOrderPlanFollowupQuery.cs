using MediatR;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderPlanFollowup;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderFlowups.Queries
{
    public class GetOrderPlanFollowupQuery : IRequest<OrderPlanFollowupCreateVM>
    {
        public int OrderID { get; set; }
    }
    public class GetOrderPlanFollowupQueryHandler : IRequestHandler<GetOrderPlanFollowupQuery, OrderPlanFollowupCreateVM>
    {
        private readonly IPlan_OrderFollowupService plan_OrderFlowupService;

        public GetOrderPlanFollowupQueryHandler(IPlan_OrderFollowupService _plan_OrderFlowupService)
        {
            plan_OrderFlowupService = _plan_OrderFlowupService;
        }
        public async Task<OrderPlanFollowupCreateVM> Handle(GetOrderPlanFollowupQuery request, CancellationToken cancellationToken)
        {
            return await plan_OrderFlowupService.GetOrderPlanFollowup(request.OrderID, cancellationToken);
        }
    }
}
