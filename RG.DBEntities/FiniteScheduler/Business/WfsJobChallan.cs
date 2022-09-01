using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsJobChallan
    {
        public WfsJobChallan()
        {
            WfsJobDetail = new HashSet<WfsJobDetail>();
        }

        public long JobChallanId { get; set; }
        public long JobId { get; set; }
        public long ReceivingMasterId { get; set; }
        public double JobWeight { get; set; }

        public virtual WfsJobMaster Job { get; set; }
        public virtual ICollection<WfsJobDetail> WfsJobDetail { get; set; }
    }
}
