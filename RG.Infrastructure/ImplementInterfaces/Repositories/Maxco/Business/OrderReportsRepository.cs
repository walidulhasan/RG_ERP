using RG.Application.Contracts.Maxco.Buisness.OrderReports.Queries.RequestResponseModel;
using RG.Application.Interfaces.Repositories.Maxco.Business;
using RG.Application.ViewModel.Maxco.Business.OrderReports;
using RG.Infrastructure.Persistence.MaxcoDB;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RG.Infrastructure.ImplementInterfaces.Repositories.Maxco.Business
{
    public class OrderReportsRepository : IOrderReportsRepository
    {
        private readonly MaxcoDBContext _dbCon;

        public OrderReportsRepository(MaxcoDBContext dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<List<OrderShipmentBalanceReportVM>> GetOrderShipmentBalanceReportData(int buyerID, int orderID, DateTime dateFrom, DateTime dateTo)
        {
            List<OrderShipmentBalanceReportVM> data = new();
            try
            {
                await _dbCon.LoadStoredProc("rpt.USP_OrderShipmentBalance")
                   .WithSqlParam("DateFrom", dateFrom)
                   .WithSqlParam("DateTo", dateTo)
                   .WithSqlParam("BuyerID", buyerID)
                   .WithSqlParam("OrderID", orderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       data = handler.ReadToList<OrderShipmentBalanceReportVM>() as List<OrderShipmentBalanceReportVM>;
                       

                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }

        public async Task<List<ShipmentOrderInfoRM>> GetShipmentOrderInfo(int orderID, CancellationToken cancellationToken)
        {
            List<ShipmentOrderInfoRM> data = new();
            try
            {
                await _dbCon.LoadStoredProc("rpt.USP_GetOrderShipment")

                   .WithSqlParam("OrderID", orderID)
                   .ExecuteStoredProcAsync((handler) =>
                   {
                       data = handler.ReadToList<ShipmentOrderInfoRM>() as List<ShipmentOrderInfoRM>;


                   });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return data;
        }
    }
}
