using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class PrintingIssuanceMaster
    {
        public PrintingIssuanceMaster()
        {
            PrintingIssuanceDetail = new HashSet<PrintingIssuanceDetail>();
        }

        public int PrintingJobId { get; set; }
        public int PrintingSpecificationId { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }
        public int IssuedTo { get; set; }

        public virtual ICollection<PrintingIssuanceDetail> PrintingIssuanceDetail { get; set; }
    }
}
