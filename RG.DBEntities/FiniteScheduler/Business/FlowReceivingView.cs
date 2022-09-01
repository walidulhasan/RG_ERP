using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FlowReceivingView
    {
        public long DocumentNo { get; set; }
        public long StyleId { get; set; }
        public long ReceivingMasterId { get; set; }
        public string ReceivingChallanNo { get; set; }
        public DateTime Dated { get; set; }
        public int ReceivedFrom { get; set; }
        public int ReceivedBy { get; set; }
        public int DocumentTypeId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long? Qty { get; set; }
        public int? PatternPieceId { get; set; }
        public long IssuanceMasterId { get; set; }
    }
}
