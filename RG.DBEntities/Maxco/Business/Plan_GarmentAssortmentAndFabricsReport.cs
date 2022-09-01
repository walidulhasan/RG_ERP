using System;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_GarmentAssortmentAndFabricsReport
    {
        public Guid Serial { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public string StyleName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryDateMsg { get => DeliveryDate.ToString("dd-MMM-yyyy"); }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public string FabricType { get; set; }
        public string Quality { get; set; }
        public string FabricComposition { get; set; }
        public int GSM { get; set; }
        public int FabricTypeID { get; set; }
        public int FabricQualityID { get; set; }
        public decimal FinishedWidth { get; set; }
        public int MachineTypeID { get; set; }
        public int DyeingID { get; set; }
        public int GaugeID { get; set; }
        public int FabricWeek { get; set; }
        public string FabricMonth { get; set; }
        public int FabricMonthSl { get; set; }
        public string GsFtFwFcFqMtDlGu { get; set; }
        public int NumberofGarments { get; set; }
        public decimal MainFabricRequiredQuantity { get; set; }
        public decimal MainFabricUseConsumption { get; set; }
        public decimal RibRequiredQuantity { get; set; }
        public decimal RibUseConsumption { get; set; }
        public int PlanID { get; set; }
        public DateTime? OrderReceiveDate { get; set; }
        public string OrderReceiveDateMsg { get=>OrderReceiveDate==null?"":OrderReceiveDate.Value.ToString("dd-MMM-yyyy"); }
        public decimal WastagePercent { get; set; }
        public DateTime CreationDate { get; set; }
        public int StyleID { get; set; }
    }
}
