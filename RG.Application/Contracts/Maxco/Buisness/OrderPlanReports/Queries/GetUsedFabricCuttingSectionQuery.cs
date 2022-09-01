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
    public class GetUsedFabricCuttingSectionQuery : IRequest<List<PlanUsedFabricCuttingSectionRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
    }
    public class GetUsedFabricCuttingSectionQueryHandler : IRequestHandler<GetUsedFabricCuttingSectionQuery, List<PlanUsedFabricCuttingSectionRM>>
    {
        private readonly IOrderPlanReportsService _orderPlanReportsService;

        public GetUsedFabricCuttingSectionQueryHandler(IOrderPlanReportsService orderPlanReportsService)
        {
            _orderPlanReportsService = orderPlanReportsService;
        }
        public async Task<List<PlanUsedFabricCuttingSectionRM>> Handle(GetUsedFabricCuttingSectionQuery request, CancellationToken cancellationToken)
        {
            return await _orderPlanReportsService.GetUsedFabricCuttingSection(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID, cancellationToken);
        }

       
    }
}
