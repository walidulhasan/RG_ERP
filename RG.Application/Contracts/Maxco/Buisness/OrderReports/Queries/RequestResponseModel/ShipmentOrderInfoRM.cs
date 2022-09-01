using System;

namespace RG.Application.Contracts.Maxco.Buisness.OrderReports.Queries.RequestResponseModel
{
    public class ShipmentOrderInfoRM
    {
        public int EPIM_ID { get; set; }
        public string BuyerName { get; set; }
        public long OrderID { get; set; }
        public string OrderNo { get; set; }
        public int OrderQty { get; set; }
        public string InvoiceNo { get; set; }
        public string CountryName { get; set; }
        public DateTime ExfactoryDate { get; set; }
        public string ExfactoryDateMsg { get { return ExfactoryDate.ToString("dd-MMM-yyyy"); } }
        public int NoOfCartons { get; set; }
        public int ExportQty { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalValue { get; set; }
    }
}
