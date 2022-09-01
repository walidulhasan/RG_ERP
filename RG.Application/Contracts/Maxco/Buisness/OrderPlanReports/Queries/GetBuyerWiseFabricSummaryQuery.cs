using MediatR;
using RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderPlanReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries
{
    public class GetBuyerWiseFabricSummaryQuery:IRequest<List<GarmentAssortmentAndFabricsInfoRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
    }
    public class GetBuyerWiseFabricSummaryQueryHandler : IRequestHandler<GetBuyerWiseFabricSummaryQuery, List<GarmentAssortmentAndFabricsInfoRM>>
    {
        private readonly IOrderPlanReportsService orderPlanReportsService;

        public GetBuyerWiseFabricSummaryQueryHandler(IOrderPlanReportsService _orderPlanReportsService)
        {
            orderPlanReportsService = _orderPlanReportsService;
        }
        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> Handle(GetBuyerWiseFabricSummaryQuery request, CancellationToken cancellationToken)
        {
            return await orderPlanReportsService.GetBuyerWiseFabricSummaryReport(request.DateFrom,request.DateTo,request.BuyerID,request.OrderID);
        }
    }
}
