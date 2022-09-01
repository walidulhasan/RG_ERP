using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class CmtStockTransaction
    {
        public long CmtStockTransactionId { get; set; }
        public long? CmtDocumentTypeId { get; set; }
        public long? CmtDocumentNo { get; set; }
        public DateTime? CmtTransactionDate { get; set; }
        public long? CmtMrpitemCode { get; set; }
        public long? AttributeInstanceId { get; set; }
        public long? CmtPatternPieceId { get; set; }
        public long? CmtBundleId { get; set; }
        public long? CmtSizeId { get; set; }
        public long? CmtColorId { get; set; }
        public long? CmtQuantity { get; set; }
        public double? CmtPerPieceRate { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
