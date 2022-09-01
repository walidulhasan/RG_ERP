using MediatR;
using RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries
{
    public class GetOrderWisePlanVersionsQuery : IRequest<List<Plan_VersionsRM>>
    {
        public int OrderID { get; set; }
    }
    public class GetOrderWisePlanVersionsQueryHandler : IRequestHandler<GetOrderWisePlanVersionsQuery, List<Plan_VersionsRM>>
    {
        private readonly IPlan_VersionsService plan_VersionsService;

        public GetOrderWisePlanVersionsQueryHandler(IPlan_VersionsService _plan_VersionsService)
        {
            plan_VersionsService = _plan_VersionsService;
        }
        public async Task<List<Plan_VersionsRM>> Handle(GetOrderWisePlanVersionsQuery request, CancellationToken cancellationToken)
        {
            return await plan_VersionsService.GetOrderWisePlanVersions(request.OrderID, cancellationToken);
        }
    }
}
