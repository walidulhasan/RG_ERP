using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MmReportStockTransactions
    {
        public int DocumentTypeId { get; set; }
        public long DocumentNo { get; set; }
        public DateTime DocumentDate { get; set; }
        public string BuyerName { get; set; }
        public string Mrpname { get; set; }
        public long AttributeInstanceId { get; set; }
        public string OrderNo { get; set; }
        public string ModelNo { get; set; }
        public double Quantity { get; set; }
        public int UserSelectedUnit { get; set; }
        public double RateWrtbaseUnit { get; set; }
        public string StoreLocationName { get; set; }
        public string StoreName { get; set; }
    }
}
