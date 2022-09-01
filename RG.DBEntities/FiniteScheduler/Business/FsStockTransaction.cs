using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsStockTransaction
    {
        public long StockTransactionId { get; set; }
        public int DocumentTypeId { get; set; }
        public long DocumentNo { get; set; }
        public long AttributeInstanceId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long Quantity { get; set; }
        public int? PatternPieceId { get; set; }
        public long? FabricColorId { get; set; }
        public long BundleId { get; set; }
        public bool? IsBarCode { get; set; }
        public byte? QualityId { get; set; }
    }
}
