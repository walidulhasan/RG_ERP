using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class FabricFloorStatusRM
    {
        public DateTime ProcessDate { get; set; }
        public string ProcessDateMsg { get { return ProcessDate.ToString("dd-MMM-yyyy"); } }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDateMsg { get { return OrderDate.ToString("dd-MMM-yyyy"); } }
        public string LotNo { get; set; }
        public string Factory { get; set; }
        public long LotID { get; set; }
        public string PantoneNo { get; set; }
        public string FabricComposition { get; set; }
        public string FabricQuality { get; set; }
        public decimal FinishedWidth { get; set; }
        public int GSM { get; set; }
        public decimal BatchQty { get; set; }
        public int ProcessDayDifference { get { return (int)(DateTime.Now - ProcessDate).TotalDays; } }
    }
}
