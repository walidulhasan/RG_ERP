using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsBundleCartDetail
    {
        public long Id { get; set; }
        public long CartMasterId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long PatternPieceId { get; set; }
        public long AttributeInstanceId { get; set; }
        public int BundleQty { get; set; }
        public long BundleId { get; set; }
        public int BundleNo { get; set; }
        public byte? Status { get; set; }

        public virtual FsBundleCartMaster CartMaster { get; set; }
    }
}
