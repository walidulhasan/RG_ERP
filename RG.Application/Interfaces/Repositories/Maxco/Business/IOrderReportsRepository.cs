using RG.Application.Contracts.Maxco.Buisness.OrderReports.Queries.RequestResponseModel;
using RG.Application.ViewModel.Maxco.Business.OrderReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Application.Interfaces.Repositories.Maxco.Business
{
    public interface IOrderReportsRepository
    {
        Task<List<OrderShipmentBalanceReportVM>> GetOrderShipmentBalanceReportData(int buyerID,int orderID,DateTime dateFrom,DateTime dateTo);
        Task<List<ShipmentOrderInfoRM>> GetShipmentOrderInfo(int orderID, CancellationToken cancellationToken);
    }
}
