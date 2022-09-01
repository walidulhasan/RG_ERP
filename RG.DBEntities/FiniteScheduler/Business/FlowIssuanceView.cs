using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FlowIssuanceView
    {
        public long StyleId { get; set; }
        public long IssuanceMasterId { get; set; }
        public DateTime Dated { get; set; }
        public int IssuanceFrom { get; set; }
        public int IssuedTo { get; set; }
        public int DocumentTypeId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long? Qty { get; set; }
        public int? PatternPieceId { get; set; }
        public string ColorName { get; set; }
        public int ChallanStatusId { get; set; }
        public long StockTransactionId { get; set; }
    }
}
