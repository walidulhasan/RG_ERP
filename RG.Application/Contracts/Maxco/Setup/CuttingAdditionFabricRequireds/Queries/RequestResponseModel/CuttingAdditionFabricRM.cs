using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Setup.CuttingAdditionFabricRequireds.Queries.RequestResponseModel
{
    public class CuttingAdditionFabricRM
    {
        public int ID { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime RequisitionDate { get; set; }
        public string RequisitionDateStr { get { return RequisitionDate.ToString("dd-MMM-yyyy");} }
        public decimal RequisitionQuantity { get; set; }
        public decimal? PlanQuantity { get; set; }
        //public decimal? StandardEfficiencyPercent { get; set; }
        //public decimal? OverAllEfficiencyPercent { get; set; }
    }
}
