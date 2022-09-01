using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class GreigeFabricYarnSpecification
    {
        public int Id { get; set; }
        public int GreigeFabricCodeId { get; set; }
        public long? YarnCountId { get; set; }
        public int? YarnCompositionId { get; set; }
        public byte? YarnQualityId { get; set; }
        public byte? YarnDyeingId { get; set; }
        public string Color { get; set; }
        public byte? YarnDesignId { get; set; }
        public byte? YarnDyeingMethodId { get; set; }
        public int? FabricYarnVendorColorId { get; set; }
        public double? Utilization { get; set; }
        public bool? IsDyed { get; set; }
        public byte? YarnIndex { get; set; }
        public int? YarnPly { get; set; }

        public virtual FabricYarnVendorColorNameSetup FabricYarnVendorColor { get; set; }
        public virtual GreigeFabricCode_Setup GreigeFabricCode { get; set; }
        public virtual FabricYarnComposition_Setup YarnComposition { get; set; }
        public virtual FabricYarnCount_Setup YarnCount { get; set; }
        public virtual FabricYarnDyeing_Setup YarnDyeing { get; set; }
        public virtual FabricYarnDyeingMethod_Setup YarnDyeingMethod { get; set; }
    }
}
