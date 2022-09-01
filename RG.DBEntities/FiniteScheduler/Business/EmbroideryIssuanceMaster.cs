using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class EmbroideryIssuanceMaster
    {
        public EmbroideryIssuanceMaster()
        {
            EmbroideryIssuanceDetail = new HashSet<EmbroideryIssuanceDetail>();
        }

        public int EmbroideryJobId { get; set; }
        public int EmbroiderySpecificationId { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }
        public int IssuedTo { get; set; }

        public virtual ICollection<EmbroideryIssuanceDetail> EmbroideryIssuanceDetail { get; set; }
    }
}
