using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class CottonStockTransactions
    {
        [Key]
        public long StockTransactionId { get; set; }
        public int DocumentNo { get; set; }
        public long? AttributeInstanceId { get; set; }
        public int DocumentTypeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Skuunit { get; set; }
        public int? UserSelectedUnit { get; set; }
        public double RateWrtbaseUnit { get; set; }
        public int Status { get; set; }
        public int? StoreLocationId { get; set; }
        public string LotNo { get; set; }
        public string BaleNo { get; set; }
        public double? Weight { get; set; }
        public double? Sl { get; set; }
        public double? Ur { get; set; }
        public double? Sfi { get; set; }
        public double? Str { get; set; }
        public double? Mic { get; set; }
        public double? Rd { get; set; }
        public double? Plusb { get; set; }
        public double? ColorGrade { get; set; }
        public double? Moisture { get; set; }
        public double? Trash { get; set; }
    }
}
