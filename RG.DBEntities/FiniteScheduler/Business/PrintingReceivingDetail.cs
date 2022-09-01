using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class PrintingReceivingDetail
    {
        public int EmrbroideryReceivingDetailId { get; set; }
        public int PrintingMasterId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AvailableQty { get; set; }
        public int ReceivedQty { get; set; }

        public virtual PrintingReceivingMaster PrintingMaster { get; set; }
    }
}
