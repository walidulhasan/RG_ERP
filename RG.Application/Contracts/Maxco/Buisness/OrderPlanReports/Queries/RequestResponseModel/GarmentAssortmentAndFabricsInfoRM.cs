using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class GarmentAssortmentAndFabricsInfoRM
    {
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderName { get; set; }
        public string StyleName { get; set; }
        public DateTime? OrderReceiveDate { get; set; }
        public string OrderReceiveDateMsg { get => OrderReceiveDate.HasValue? OrderReceiveDate.Value.ToString("dd-MMM-yyyy"):""; }
        public DateTime? OrderDate { get; set; }
        public string OrderDateMsg { get => OrderDate.HasValue ? OrderDate.Value.ToString("dd-MMM-yyyy") : ""; }
        public int PlanID { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public string Quality { get; set; }
        public int GSM { get; set; }
        public decimal FinishedWidth { get; set; }
        public int FabricMonthSl { get; set; }
        public string FabricMonth { get; set; }
        public int FabricWeek { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateMsg { get => DeliveryDate.ToString("dd-MMM-yyyy"); }
        public int NumberofGarments { get; set; }
        public decimal FinFabricBooking { get; set; }
        public decimal RibBooking { get; set; }
        public decimal TotalFinFabricBooking { get; set; }
        
        public decimal PlanKnittingQty { get; set; }
        public decimal KnittingQty { get; set; }
        public decimal KnittingBalance { get; set; }
        public decimal BatchQty { get; set; }
        public decimal BatchBalance { get; set; }
        public decimal FinishFabricDeliveryQty { get; set; }
        public decimal FinishFabricDeliveryBal { get; set; }
        public decimal RibQty { get; set; }
        public int NoOfOrders { get; set; }
        
        public string BatchCommitmentDateMsg { get; set; }
        public string ArtWork { get; set; }
        public string DyeingProductionUnit { get; set; }
        public string DeliveryCommitmentDateMsg { get; set; }
    }
}
