using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FlowBundleDetail
    {
        public long DetailId { get; set; }
        public long MasterId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public int PatternPieceId { get; set; }
        public long AttributeInstanceId { get; set; }
        public long BundleQty { get; set; }
    }
}
