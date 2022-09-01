using System;
using System.Collections.Generic;

namespace RG.Application.Contracts.Maxco.Buisness.Plan_OrderMasters.Queries.RequestResponseModel
{
    public class PlanOrderDetailInfoRM
    {
        public long FabricSL { get; set; }
        public int OrderID { get; set; }
        public int StyleID { get; set; }
        public int FabricTypeID { get; set; }
        public string FabricType { get; set; }
        public int FabricQualityID { get; set; }
        public string FabricQuality { get; set; }
        public int GSM { get; set; }
        public string FabricComposition { get; set; }
        public string PantoneNo { get; set; }
        public string ColorName { get; set; }
        public decimal RequiredQuantity { get; set; }
        public decimal Use { get; set; }
        public int GroupID { get; set; }
        public decimal RibQuantity { get; set; }
        public decimal RibUse { get; set; }
        public decimal TotalFabric { get; set; }
        public decimal FabricConsumpion { get; set; }
        public int StyleOrderQuantity { get; set; }
        public decimal WastagePercent { get; set; }
        public List<OrderDeliveryInfoRM> OrderDeliveryInfo { get; set; }
    }
    public class OrderDeliveryInfoRM
    {
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public long StyleID { get; set; }
        public string FabricComposition { get; set; }
        public string PantoneNo { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int WeekNo { get; set; }
        public string DeliveryDateMsg { get { return ShipmentDate.ToString("dd-MMM-yyyy"); } }
        public long NumberofGarments { get; set; }


    }
}
