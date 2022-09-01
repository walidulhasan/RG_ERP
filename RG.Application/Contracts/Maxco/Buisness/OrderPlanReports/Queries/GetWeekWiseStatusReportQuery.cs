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
    public class GetWeekWiseStatusReportQuery : IRequest<List<GarmentAssortmentAndFabricsInfoRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
    }
    public class GetWeekWiseStatusReportQueryHandler : IRequestHandler<GetWeekWiseStatusReportQuery, List<GarmentAssortmentAndFabricsInfoRM>>
    {
        private readonly IOrderPlanReportsService orderPlanReportsService;

        public GetWeekWiseStatusReportQueryHandler(IOrderPlanReportsService _orderPlanReportsService)
        {
            orderPlanReportsService = _orderPlanReportsService;
        }
        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> Handle(GetWeekWiseStatusReportQuery request, CancellationToken cancellationToken)
        {
            return await orderPlanReportsService.GetWeekWiseStatusReport(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID);
        }
    }
}