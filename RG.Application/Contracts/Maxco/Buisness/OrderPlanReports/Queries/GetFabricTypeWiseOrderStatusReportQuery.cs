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
    public class GetFabricTypeWiseOrderStatusReportQuery : IRequest<List<GarmentAssortmentAndFabricsInfoRM>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
    }
    public class GetFabricTypeWiseOrderStatusReportQueryHandler : IRequestHandler<GetFabricTypeWiseOrderStatusReportQuery, List<GarmentAssortmentAndFabricsInfoRM>>
    {
        private readonly IOrderPlanReportsService orderPlanReportsService;

        public GetFabricTypeWiseOrderStatusReportQueryHandler(IOrderPlanReportsService _orderPlanReportsService)
        {
            orderPlanReportsService = _orderPlanReportsService;
        }
        public async Task<List<GarmentAssortmentAndFabricsInfoRM>> Handle(GetFabricTypeWiseOrderStatusReportQuery request, CancellationToken cancellationToken)
        {
            return await orderPlanReportsService.GetFabricTypeWiseOrderStatusReport(request.DateFrom,request.DateTo,request.BuyerID,request.OrderID);
        }
    }
}
