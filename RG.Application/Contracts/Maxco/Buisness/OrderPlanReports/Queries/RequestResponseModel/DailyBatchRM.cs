using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class DailyBatchRM
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public DateTime ProcessDate { get; set; }
        public string ProcessDateMsg { get { return ProcessDate.ToString("dd-MMM-yyyy"); } }
        public long LotID { get; set; }
        public string LotNo { get; set; }
        public string PantoneNo { get; set; }
        public string FabricQuality { get; set; }
        public decimal BatchQty { get; set; }
        public string LotType { get; set; }
    }
}
