using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class MM_StockTransactions
    {
        [Key]
        public long StockTransactionID { get; set; }
        public int DocumentTypeID { get; set; }
        public long DocumentNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime DocumentDate { get; set; }
        public int BuyerID { get; set; }
        public int MRPItemCode { get; set; }
        public long AttributeInstanceID { get; set; }
        public int OrderID { get; set; }
        public int ModelID { get; set; }
        public double Quantity { get; set; }
        public int UserSelectedUnit { get; set; }
        public double Rate_WRTbaseUnit { get; set; }
        public int StoreLocationID { get; set; }
        public int Status { get; set; }
        public int? Reason { get; set; }
        public double? MovingAverage { get; set; }
        public double? AvailableQuantity { get; set; }
        public int? OldStoreLocationID { get; set; }
        public long? CompanyID { get; set; }
        public long? BusinessID { get; set; }
        public int IsNetting { get; set; }
    }
}
