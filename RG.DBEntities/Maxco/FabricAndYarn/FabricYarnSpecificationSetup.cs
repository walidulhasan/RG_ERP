using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricYarnSpecificationSetup
    {
        public long Id { get; set; }
        public long FabricSpecificationId { get; set; }
        public long YarnCountId { get; set; }
        public int YarnCompositionId { get; set; }
        public int YarnQualityId { get; set; }
        public int? YarnDyeingId { get; set; }
        public string Color { get; set; }
        public int? YarnDesignId { get; set; }
        public int? YarnDyeingMethodId { get; set; }
        public int? FabricYarnVendorColorId { get; set; }
        public double? Utilization { get; set; }
        public bool? IsDyed { get; set; }
        public int? YarnIndex { get; set; }

        public virtual FabricSpecificationSetup FabricSpecification { get; set; }
        public virtual FabricYarnCount_Setup YarnCount { get; set; }
    }
}
