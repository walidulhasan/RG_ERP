using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
   public class ArtWorkPlanRM
    {
       public int FabricMonthSl { get; set; }
       public string FabricMonth { get; set; }
        public int BuyerID { get; set; }
        public string Buyer { get; set; }
        public long OrderID { get; set; }
        public string ArtWork { get; set; }
        public int ArtWorkID { get; set; }
        public int OrderQty { get; set; } 
        public decimal FinishFabricBookingKg { get; set; }
        public decimal PlanKnittingKg { get; set; }
        public decimal KnittingKg { get; set; }
        public decimal KnittingBalanceKg { get; set; }
        public decimal BatchKg { get; set; }
        public decimal BatchBalance { get; set; }
        public decimal FinishFabricDeliveryKg { get; set; }
        public decimal RibQty { get; set; }
        public decimal FinishFabricDeliveryBalanceKg { get; set; }
    }
}
