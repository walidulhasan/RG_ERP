using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class EmbroideryIssuanceDetail
    {
        public int EmbroideryIssuanceDetailId { get; set; }
        public int EmbroideryJobId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AvailableQty { get; set; }
        public int IssuanceQty { get; set; }

        public virtual EmbroideryIssuanceMaster EmbroideryJob { get; set; }
    }
}
