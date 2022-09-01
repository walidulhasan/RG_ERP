using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FlowBundleMaster
    {
        public long Id { get; set; }
        public long StyleId { get; set; }
        public long BundleId { get; set; }
        public int BundleNo { get; set; }
        public int BundleStatusId { get; set; }
        public long? ReceivingMasterId { get; set; }
    }
}
