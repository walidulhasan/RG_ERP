using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class EmbroideryReceivingMaster
    {
        public EmbroideryReceivingMaster()
        {
            EmbroideryReceivingDetail = new HashSet<EmbroideryReceivingDetail>();
        }

        public int EmbroideryReceivingMasterId { get; set; }
        public int EmbroiderySpecificationId { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }
        public int ReceivedFrom { get; set; }

        public virtual ICollection<EmbroideryReceivingDetail> EmbroideryReceivingDetail { get; set; }
    }
}
