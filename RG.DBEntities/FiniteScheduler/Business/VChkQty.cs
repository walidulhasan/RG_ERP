using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class VChkQty
    {
        public int BundleNo { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long BundleQty { get; set; }
        public long SerialFrom { get; set; }
        public long SerialTo { get; set; }
    }
}
