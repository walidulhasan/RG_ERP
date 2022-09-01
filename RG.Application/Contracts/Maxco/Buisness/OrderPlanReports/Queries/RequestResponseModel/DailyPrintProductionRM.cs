using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class DailyPrintProductionRM
    {
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public decimal OrderPrintQty { get; set; }
        public decimal TodayRcv { get; set; }
        public decimal TotalRcv { get; set; }
        public decimal TodayPrint { get; set; }
        public decimal TotalPrint { get; set; }
        public decimal TodayDelivery { get; set; }
        public decimal TotalDelivery { get; set; }
        public string ProductionDate { get; set; }
    }
}
