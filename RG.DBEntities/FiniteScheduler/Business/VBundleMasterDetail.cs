using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VBundleMasterDetail
    {
        public long? StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public int BundleStatusId { get; set; }
        public long? Expr1 { get; set; }
        public long SerialFrom { get; set; }
        public long SerialTo { get; set; }
        public int PatternPieceId { get; set; }
        public int BundleNo { get; set; }
    }
}
