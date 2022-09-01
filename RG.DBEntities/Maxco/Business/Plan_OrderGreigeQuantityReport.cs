using System;

namespace RG.DBEntities.Maxco.Business
{
    public class Plan_OrderGreigeQuantityReport
    {
        public Guid Serial { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public decimal GreigeQuantity { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
