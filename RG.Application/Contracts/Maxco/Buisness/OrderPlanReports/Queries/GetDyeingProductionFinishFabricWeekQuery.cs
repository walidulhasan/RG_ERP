using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries
{
    public class GetDyeingProductionFinishFabricWeekQuery : IRequest<List<DyeingUnitProductionFabricWeekRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public long OrderID { get; set; }
    }
    public class GetDyeingProductionFinishFabricWeekQueryHandler : IRequestHandler<GetDyeingProductionFinishFabricWeekQuery, List<DyeingUnitProductionFabricWeekRM>>
    {
        private readonly IOrderPlanReportsService _orderPlanReportsService;

        public GetDyeingProductionFinishFabricWeekQueryHandler(IOrderPlanReportsService orderPlanReportsService)
        {
            _orderPlanReportsService = orderPlanReportsService;
        }
        public async Task<List<DyeingUnitProductionFabricWeekRM>> Handle(GetDyeingProductionFinishFabricWeekQuery request, CancellationToken cancellationToken)
        {
            return  await _orderPlanReportsService.GetDyeingProductionFinishFabricWeek(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID, cancellationToken);
        }
    }
}
