using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class SfsStockTransactionBackupNotTobeDeleted
    {
        public long StockTransactionId { get; set; }
        public int DocumentTypeId { get; set; }
        public long DocumentNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public long JobId { get; set; }
        public long SizeId { get; set; }
        public long ColorId { get; set; }
        public long Quantity { get; set; }
        public int Deleted { get; set; }
        public long? RejectedQuantity { get; set; }
        public bool? IsBarCode { get; set; }
        public byte? QualityId { get; set; }
        public long? UserId { get; set; }
    }
}
