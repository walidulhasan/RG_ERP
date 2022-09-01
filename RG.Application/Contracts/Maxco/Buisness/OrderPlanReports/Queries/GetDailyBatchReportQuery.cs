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
    public class GetDailyBatchReportQuery:IRequest<List<DailyBatchRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
    }
    public class GetDailyBatchReportQueryHandler : IRequestHandler<GetDailyBatchReportQuery, List<DailyBatchRM>>
    {
        private readonly IOrderPlanReportsService _orderPlanReportsService;

        public GetDailyBatchReportQueryHandler(IOrderPlanReportsService orderPlanReportsService)
        {
            _orderPlanReportsService = orderPlanReportsService;
        }
        public async Task<List<DailyBatchRM>> Handle(GetDailyBatchReportQuery request, CancellationToken cancellationToken)
        {
            return await _orderPlanReportsService.GetDailyBatchReport(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID, cancellationToken);
        }
    }
}
