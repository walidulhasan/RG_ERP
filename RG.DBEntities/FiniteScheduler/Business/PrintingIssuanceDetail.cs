using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class PrintingIssuanceDetail
    {
        public int PrintingIssuanceDetailId { get; set; }
        public int PrintingJobId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AvailableQty { get; set; }
        public int IssuanceQty { get; set; }

        public virtual PrintingIssuanceMaster PrintingJob { get; set; }
    }
}
