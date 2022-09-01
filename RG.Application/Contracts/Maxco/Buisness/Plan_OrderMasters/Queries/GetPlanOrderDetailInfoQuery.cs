using MediatR;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries
{
    public class GetPlanOrderDetailInfoQuery : IRequest<List<PlanOrderDetailInfoRM>>
    {
        public int OrderID { get; set; }
    }
    public class GetPlanOrderDetailInfoQueryHandler : IRequestHandler<GetPlanOrderDetailInfoQuery, List<PlanOrderDetailInfoRM>>
    {
        private readonly IPlan_OrderMasterService plan_OrderMasterService;

        public GetPlanOrderDetailInfoQueryHandler(IPlan_OrderMasterService _plan_OrderMasterService)
        {
            plan_OrderMasterService = _plan_OrderMasterService;
        }
        public async Task<List<PlanOrderDetailInfoRM>> Handle(GetPlanOrderDetailInfoQuery request, CancellationToken cancellationToken)
        {
            return await plan_OrderMasterService.GetPlanOrderDetailInfo(request.OrderID, cancellationToken);
        }
    }
}
