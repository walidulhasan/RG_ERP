using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VBundleInfo
    {
        public long BundleId { get; set; }
        public int BundleNo { get; set; }
        public int BundleStatusId { get; set; }
        public long? StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long BundleQty { get; set; }
        public long SerialFrom { get; set; }
        public long SerialTo { get; set; }
        public string BodyPart { get; set; }
        public int TrimId { get; set; }
        public string PatternPiece { get; set; }
    }
}
