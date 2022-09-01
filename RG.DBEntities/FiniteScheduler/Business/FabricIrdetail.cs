using System;
using System.Collections.Generic;

namespace RG.DBEntities.FiniteScheduler.Business
{
    public partial class FabricIrdetail
    {
        public int FabricIrdetailId { get; set; }
        public int FabricIrmasterId { get; set; }
        public string Color { get; set; }
        public double Width { get; set; }
        public double Gsm { get; set; }
        public double AllocatedQty { get; set; }
        public double QtyM { get; set; }
        public double QtyKg { get; set; }
        public long AttributeInstanceId { get; set; }
        public int? VariationId { get; set; }
        public string Description { get; set; }
        public double? CutWastage { get; set; }
        public double? Scrap { get; set; }

        public virtual FabricIrmaster FabricIrmaster { get; set; }
    }
}
