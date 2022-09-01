using System;
using System.Collections.Generic;

namespace RG.Application.ViewModel.Maxco.Business.OrderPlanReports
{
    public class WeeklySummaryVM
    {
        public WeeklySummaryVM()
        {
            OrderInfo = new List<OrderInfo>();
            OrderGreigeFabric = new List<OrderGreigeFabric>();
            OrderFinishFabric = new List<OrderFinishFabric>();
        }
        public List<OrderInfo> OrderInfo { get; set; }
        public List<OrderGreigeFabric> OrderGreigeFabric { get; set; }
        public List<OrderFinishFabric> OrderFinishFabric { get; set; }
    }
    public class OrderInfo {
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderName { get; set; }
        public string PantoneNo { get; set; }
        public int FabricMonthSl { get; set; }
        public string FabricMonth { get; set; }
        public int FabricWeek { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int NumberofGarments { get; set; }
        public decimal FinFabricBooking { get; set; }
        public decimal RibBooking { get; set; }
        public decimal PlanKnittingQty { get; set; }
        public decimal KnittingQty { get; set; }
        public decimal KnittingBalance { get; set; }
        public decimal BatchQty { get; set; }
        public decimal BatchBalance { get; set; }
        public decimal FinishFabricDeliveryQty { get; set; }
        public decimal FinishFabricDeliveryBal { get; set; }
        
        public decimal RibQty { get; set; }
        public int NoOfOrders { get; set; }
    }
    public class OrderGreigeFabric
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public decimal GreigeQuantity { get; set; }

    }
    public class OrderFinishFabric
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public string PantoneNo { get; set; }
        public decimal BatchQty { get; set; }
        public decimal FinishQty { get; set; }
        public decimal RibQty { get; set; }

    }
}
