using MediatR;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.DBEntities.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries
{
    public class GetOrderPlanningVersionDetailQuery:IRequest<Plan_OrderMaster>
    {
        public int OrderID { get; set; }
        public int PlanVersionID { get; set; }
    }
    public class GetOrderPlanningVersionDetailQueryHandler : IRequestHandler<GetOrderPlanningVersionDetailQuery, Plan_OrderMaster>
    {
        private readonly IPlan_OrderMasterService plan_OrderMasterService;

        public GetOrderPlanningVersionDetailQueryHandler(IPlan_OrderMasterService _plan_OrderMasterService)
        {
            plan_OrderMasterService = _plan_OrderMasterService;
        }
        public async Task<Plan_OrderMaster> Handle(GetOrderPlanningVersionDetailQuery request, CancellationToken cancellationToken)
        {
            return await plan_OrderMasterService.GetOrderPlanningVersionDetail(request.OrderID, request.PlanVersionID);
        }
    }
}
