using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries
{
    public class GetPlannedOrderStatusQuery : IRequest<List<GarmentAssortmentAndFabricsInfoRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }

    }
    public class GetPlannedOrderStatusQueryHandler : IRequestHandler<GetPlannedOrderStatusQuery, List<GarmentAssortmentAndFabricsInfoRM>>
    {
        private readonly IOrderPlanReportsService orderPlanReportsService;

        public GetPlannedOrderStatusQueryHandler(IOrderPlanReportsService _orderPlanReportsService)
        {
            orderPlanReportsService = _orderPlanReportsService;
        }
        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> Handle(GetPlannedOrderStatusQuery request, CancellationToken cancellationToken)
        {
            return await orderPlanReportsService.GetPlannedOrderStatusReport(request.DateFrom, request.DateTo, request.BuyerID, request.OrderID);
        }
    }
}
