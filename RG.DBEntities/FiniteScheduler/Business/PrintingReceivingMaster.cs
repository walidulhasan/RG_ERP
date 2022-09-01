using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class PrintingReceivingMaster
    {
        public PrintingReceivingMaster()
        {
            PrintingReceivingDetail = new HashSet<PrintingReceivingDetail>();
        }

        public int PrintingReceivingMasterId { get; set; }
        public int PrintingSpecificationId { get; set; }
        public int UserId { get; set; }
        public DateTime Dated { get; set; }
        public int ReceivedFrom { get; set; }

        public virtual ICollection<PrintingReceivingDetail> PrintingReceivingDetail { get; set; }
    }
}
