using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class BundleDetail
    {
        public long BundleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public int PatternPieceId { get; set; }
        public long Id { get; set; }
        public long AttributeInstanceId { get; set; }
        public long BundleQty { get; set; }
        public long SerialFrom { get; set; }
        public long SerialTo { get; set; }
        public string Shade { get; set; }
    }
}
