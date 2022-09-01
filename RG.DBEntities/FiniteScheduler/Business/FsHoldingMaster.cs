using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsHoldingMaster
    {
        public long StyleId { get; set; }
        public long ColorId { get; set; }
        public long SizeId { get; set; }
        public long BundleId { get; set; }
        public long Quantity { get; set; }
        public int? Status { get; set; }
        public long Id { get; set; }
        public long? BundleNo { get; set; }
        public long? ChallanId { get; set; }
    }
}
