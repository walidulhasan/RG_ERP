using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class AgencyStockTransactions
    {
        public long StockTransactionId { get; set; }
        public int DocumentTypeId { get; set; }
        public long DocumentNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public int MrpitemCode { get; set; }
        public long AttributeInstanceId { get; set; }
        public long BundleId { get; set; }
        public long PatternPieceId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public double Quantity { get; set; }
        public bool? IsBarcodedEntry { get; set; }
    }
}
