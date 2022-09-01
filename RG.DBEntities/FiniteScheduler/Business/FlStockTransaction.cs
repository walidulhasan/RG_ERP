using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FlStockTransaction
    {
        public long StockTransactionId { get; set; }
        public int DocumentTypeId { get; set; }
        public long DocumentNo { get; set; }
        public long AttributeInstanceId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long Quantity { get; set; }
        public int JobTicketId { get; set; }
        public int? PatternPieceId { get; set; }
        public long? FabricColorId { get; set; }
        public int PartialId { get; set; }
    }
}
