using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries
{
    public class GetManagementStatusReportQuery : IRequest<List<ManagementStatusRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
    }
    public class GetManagementStatusReportQueryHandler : IRequestHandler<GetManagementStatusReportQuery, List<ManagementStatusRM>>
    {
        private readonly IOrderPlanReportsService _orderPlanReportsService;

        public GetManagementStatusReportQueryHandler(IOrderPlanReportsService orderPlanReportsService)
        {
            _orderPlanReportsService = orderPlanReportsService;
        }
        public async Task<List<ManagementStatusRM>> Handle(GetManagementStatusReportQuery request, CancellationToken cancellationToken)
        {
            return await _orderPlanReportsService.GetManagementStatusReport(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID, cancellationToken);
        }
    }
}
