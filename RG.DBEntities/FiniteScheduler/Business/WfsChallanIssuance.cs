using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsChallanIssuance
    {
        public WfsChallanIssuance()
        {
            WfsChallanIssuanceDetail = new HashSet<WfsChallanIssuanceDetail>();
        }

        public long IssuanceChallanId { get; set; }
        public DateTime IssuanceChallanDate { get; set; }
        public long ReceivingChallanId { get; set; }
        public long StyleId { get; set; }
        public int? UserId { get; set; }
        public double GarmentWeight { get; set; }
        public string Comments { get; set; }

        public virtual ICollection<WfsChallanIssuanceDetail> WfsChallanIssuanceDetail { get; set; }
    }
}
