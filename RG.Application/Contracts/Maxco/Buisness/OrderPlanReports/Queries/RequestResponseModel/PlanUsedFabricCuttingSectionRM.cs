using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class PlanUsedFabricCuttingSectionRM
    {
        public DateTime Productiondate { get; set; }
        public string ProductiondateST { get { return Productiondate.ToString("dd-MMM-yyyy"); } }
        public int MonthSL { get; set; }
        public string MonthYear {get;set;}

        public long OrderId { get; set; }
        public string OrderNo { get; set; }
        public string StyleName { get; set; }
        public string PantoneNo { get; set; }
        public decimal RollWeight { get; set; }
        public int TotalCuttingQty { get; set; }
        public decimal InputQty { get; set; }
        

    }
}
