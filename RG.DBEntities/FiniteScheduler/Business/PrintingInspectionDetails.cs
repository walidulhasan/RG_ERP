using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class PrintingInspectionDetails
    {
        public int PrintingInspectionDetailId { get; set; }
        public int PrintingInspectionMasterId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AvailableQty { get; set; }
        public int RejectedQty { get; set; }

        public virtual PrintingInspectionMaster PrintingInspectionMaster { get; set; }
    }
}
