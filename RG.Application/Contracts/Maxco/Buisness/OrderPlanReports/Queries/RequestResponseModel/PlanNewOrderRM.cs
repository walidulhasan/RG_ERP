using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class PlanNewOrderRM
    {
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNO { get; set; }
        public string ShipmentMonth { get; set; }
        public int ShipmentMonthSL { get; set; }
        public int FabricWeek { get; set; }
        public DateTime? PoReceivedDate { get; set; }
        public string PoReceivedDateST { get { return PoReceivedDate != null ? PoReceivedDate.Value.ToString("dd-MMM-yyyy") : ""; } }

        public DateTime ShipmentDate { get; set; }
        public string ShipmentDateST { get { return ShipmentDate.ToString("dd-MMM-yyyy"); } }
        public string StyleName { get; set; }
        public string ColorName { get; set; }
        public string PantoneNo { get; set; }
        public string FabricQuality { get; set; }
        public string ArtWorkName { get; set; }
        public decimal FinishedWidth { get; set; }
        public int GSM { get; set; }
        public DateTime?KnittingStartDate { get; set; }
        public string KnittingStartDateST { get { return KnittingStartDate != null ? KnittingStartDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public DateTime? KnittingEndDate { get; set; }
        public string KnittingEndDateST { get { return KnittingEndDate != null ? KnittingEndDate.Value.ToString("dd-MMM-yyyy") : ""; } }

        public int KnittingDuration { get; set; }
        public string PlanDyeingProductionUnit { get; set; }
        public DateTime ? PlanFabricDeliveryStartDate { get; set; }
        public string PlanFabricDeliveryStartDateST { get { return PlanFabricDeliveryStartDate != null ? PlanFabricDeliveryStartDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public DateTime? PlanFabricDeliveryEndDate { get; set; }
        public string PlanFabricDeliveryEndDateST { get { return PlanFabricDeliveryEndDate != null ? PlanFabricDeliveryEndDate.Value.ToString("dd-MMM-yyyy") : ""; } }

        public int PlanDeliveryDuration { get; set; }
        public DateTime? PlanBatchCommitmentDate { get; set; }
        public string PlanBatchCommitmentDateST { get { return PlanBatchCommitmentDate != null ? PlanBatchCommitmentDate.Value.ToString("dd-MMM-yyyy") : ""; } }
        public int ShipmentOrderQuantity { get; set; }

        public decimal FinishFabricBookingKg { get; set; }
        public decimal PlanKnittingKg { get; set; }
        public decimal KnittingKG { get; set; }
        public decimal KnittingBalance { get; set; }
        public decimal BatchKg { get; set; }
        public decimal BatchBalance { get; set; }
        public decimal FinishFabricMain { get; set; }
        public decimal FinishFabricRib { get; set; }
        public decimal FinishFabricBalance { get; set; }



    }
}
