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
    public class GetFabricFloorStatusReportQuery:IRequest<List<FabricFloorStatusRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
    }
    public class GetFabricFloorStatusReportQueryHandler : IRequestHandler<GetFabricFloorStatusReportQuery, List<FabricFloorStatusRM>>
    {
        private readonly IOrderPlanReportsService _orderPlanReportsService;

        public GetFabricFloorStatusReportQueryHandler(IOrderPlanReportsService orderPlanReportsService)
        {
            _orderPlanReportsService = orderPlanReportsService;
        }
        public async Task<List<FabricFloorStatusRM>> Handle(GetFabricFloorStatusReportQuery request, CancellationToken cancellationToken)
        {
            return await _orderPlanReportsService.GetFabricFloorStatusReport(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID, cancellationToken);
        }
    }
}
