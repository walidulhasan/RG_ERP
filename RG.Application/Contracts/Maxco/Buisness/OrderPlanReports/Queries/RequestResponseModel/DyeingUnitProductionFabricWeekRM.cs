using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class DyeingUnitProductionFabricWeekRM
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int BuyerID { get; set; }
        public string Buyer { get; set; }
        public string DyeingProductinUnit { get; set; }
        public int OrderQty { get; set; }
        public decimal DyeingPlanKg { get; set; }
        public decimal FabricBookingKg { get; set; }
        public decimal FinishedFabricKg { get; set; }
        public decimal PlanBalanceKg { get; set; }
        public int MonthSl { get; set; }
        public int FabricWeek { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public long StyleID { get; set; }
        public decimal DyeingWastagePercentage { get; set; }
        public decimal UnitWiseBuyerTotal { get { return PlanBalanceKg + FinishedFabricKg + FabricBookingKg + DyeingPlanKg; } }


    }
}
