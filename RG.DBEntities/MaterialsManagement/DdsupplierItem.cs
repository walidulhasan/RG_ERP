using System;
using System.Collections.Generic;

namespace RG.DBEntities.MaterialsManagement
{
    public partial class DdsupplierItem
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int ItemId { get; set; }
        public bool IsMrp { get; set; }
        public int? UnitId { get; set; }
        public double? UnitPrice { get; set; }
        public double? LeadTime { get; set; }
        public double? LastPrice { get; set; }

        public virtual Ddsupplier Supplier { get; set; }
        public virtual DdunitSetup Unit { get; set; }
    }
}
