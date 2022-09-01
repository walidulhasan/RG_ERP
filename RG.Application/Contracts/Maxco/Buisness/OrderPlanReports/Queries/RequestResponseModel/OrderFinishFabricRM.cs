namespace RG.Application.Contracts.Maxco.Buisness.OrderPlanReports.Queries.RequestResponseModel
{
    public class OrderFinishFabricRM
    {
        public int OrderID { get; set; }
        public string OrderName { get; set; }
        public string PantoneNo { get; set; }
        public decimal BatchQty { get; set; }
        public decimal FinishQty { get; set; }
        public decimal RibQty { get; set; }
        public decimal TotalFinishQty { get; set; }

    }
}
