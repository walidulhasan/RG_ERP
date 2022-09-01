using System;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_OrderBatchAndFinishQuantityReport
    {
        public Guid Serial { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public string PantoneNo { get; set; }
        public decimal BatchQty { get; set; }
        public decimal FinishQty { get; set; }
        public decimal RibQty { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
