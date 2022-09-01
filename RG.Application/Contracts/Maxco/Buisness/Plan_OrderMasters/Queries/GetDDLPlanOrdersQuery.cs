using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries
{
    public class GetDDLPlanOrdersQuery:IRequest<List<SelectListItem>>
    {
        public bool? IsOrderClosed { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLPlanOrdersQueryHandler : IRequestHandler<GetDDLPlanOrdersQuery, List<SelectListItem>>
    {
        private readonly IPlan_OrderMasterService plan_OrderMasterService;

        public GetDDLPlanOrdersQueryHandler(IPlan_OrderMasterService _plan_OrderMasterService)
        {
            plan_OrderMasterService = _plan_OrderMasterService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLPlanOrdersQuery request, CancellationToken cancellationToken)
        {
            return await plan_OrderMasterService.DDLPlanOrders(request.IsOrderClosed, request.Predict, cancellationToken);
        }
    }
}
