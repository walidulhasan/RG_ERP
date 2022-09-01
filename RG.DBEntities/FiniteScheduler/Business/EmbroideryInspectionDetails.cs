using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class EmbroideryInspectionDetails
    {
        public int EmbroideryInspectionDetailId { get; set; }
        public int EmrbroideryInspectionMasterId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int AvailableQty { get; set; }
        public int RejectedQty { get; set; }

        public virtual EmbroideryInspectionMaster EmrbroideryInspectionMaster { get; set; }
    }
}
