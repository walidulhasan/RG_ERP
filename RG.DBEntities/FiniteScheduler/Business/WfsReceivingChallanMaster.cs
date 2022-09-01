using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class WfsReceivingChallanMaster
    {
        public WfsReceivingChallanMaster()
        {
            WfsReceivingChallanDetail = new HashSet<WfsReceivingChallanDetail>();
        }

        public long ReceivingMasterId { get; set; }
        public long IssuanceMasterId { get; set; }
        public int? UserId { get; set; }
        public long StyleId { get; set; }
        public DateTime ReceivingDate { get; set; }
        public double GarmentWeight { get; set; }
        public string Comments { get; set; }
        public int IsRewash { get; set; }

        public virtual ICollection<WfsReceivingChallanDetail> WfsReceivingChallanDetail { get; set; }
    }
}
