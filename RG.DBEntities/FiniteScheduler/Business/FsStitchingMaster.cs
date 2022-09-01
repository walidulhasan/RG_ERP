using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FsStitchingMaster
    {
        public FsStitchingMaster()
        {
            FsStitchingDetail = new HashSet<FsStitchingDetail>();
        }

        public long Id { get; set; }
        public long StyleId { get; set; }
        public long ReceivingMasterId { get; set; }
        public long? BundleId { get; set; }
        public DateTime Rdate { get; set; }

        public virtual ICollection<FsStitchingDetail> FsStitchingDetail { get; set; }
    }
}
