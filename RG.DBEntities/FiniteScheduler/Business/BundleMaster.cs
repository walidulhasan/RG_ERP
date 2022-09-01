using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class BundleMaster
    {
        public long BundleId { get; set; }
        public int BundleNo { get; set; }
        public int? JobTicketId { get; set; }
        public int BundleStatusId { get; set; }
        public int WorkCenterId { get; set; }
        public long? StyleId { get; set; }
        public DateTime? Rdate { get; set; }
    }
}
