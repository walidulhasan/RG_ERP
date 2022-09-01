using RG.Application.Contracts.Maxco.Buisness.OrderReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.Interfaces.Services.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderReports;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Services.Maxco.Business
{
    public class OrderReportsService : IOrderReportsService
    {
        private readonly IOrderReportsRepository _orderReportsRepository;

        public OrderReportsService(IOrderReportsRepository orderReportsRepository)
        {
            _orderReportsRepository = orderReportsRepository;
        }
        public async Task<List<OrderShipmentBalanceReportVM>> GetOrderShipmentBalanceReportData(int buyerID, int orderID, DateTime dateFrom, DateTime dateTo)
        {
            return await _orderReportsRepository.GetOrderShipmentBalanceReportData(buyerID, orderID, dateFrom, dateTo);
        }

        public async Task<List<ShipmentOrderInfoRM>> GetShipmentOrderInfo(int orderID, CancellationToken cancellationToken)
        {
            return await _orderReportsRepository.GetShipmentOrderInfo(orderID, cancellationToken);
        }
    }
}
