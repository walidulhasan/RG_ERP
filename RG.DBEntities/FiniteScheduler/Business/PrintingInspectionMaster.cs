using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class PrintingInspectionMaster
    {
        public PrintingInspectionMaster()
        {
            PrintingInspectionDetails = new HashSet<PrintingInspectionDetails>();
        }

        public int PrintingInspectionMasterId { get; set; }
        public int PrintingSpecificationId { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }

        public virtual ICollection<PrintingInspectionDetails> PrintingInspectionDetails { get; set; }
    }
}
