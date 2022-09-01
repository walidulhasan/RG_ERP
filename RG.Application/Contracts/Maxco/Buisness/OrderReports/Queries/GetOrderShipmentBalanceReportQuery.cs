using MediatR;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderReports.Queries
{
    public class GetOrderShipmentBalanceReportQuery:IRequest<List<OrderShipmentBalanceReportVM>>
    {
        public int BuyerID { get; set; }
        public int OrderID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
    public class GetOrderShipmentBalanceReportQueryHandler : IRequestHandler<GetOrderShipmentBalanceReportQuery, List<OrderShipmentBalanceReportVM>>
    {
        private readonly IOrderReportsService _orderReportsService;

        public GetOrderShipmentBalanceReportQueryHandler(IOrderReportsService orderReportsService)
        {
            _orderReportsService = orderReportsService;
        }
        public async Task<List<OrderShipmentBalanceReportVM>> Handle(GetOrderShipmentBalanceReportQuery request, CancellationToken cancellationToken)
        {
            return await _orderReportsService.GetOrderShipmentBalanceReportData(request.BuyerID, request.OrderID, request.DateFrom, request.DateTo);
        }
    }
}
