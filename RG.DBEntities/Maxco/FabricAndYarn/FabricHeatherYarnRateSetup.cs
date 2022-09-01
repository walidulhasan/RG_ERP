using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricHeatherYarnRateSetup
    {
        public int Id { get; set; }
        public int FabricYarnVendorId { get; set; }
        public int FabricYarnVendorColorNameId { get; set; }
        public int FabricYarnVendorColorId { get; set; }
        public int FabricYarnQualityId { get; set; }
        public int FabricYarnCompositionId { get; set; }
        public int FabricYarnCountId { get; set; }
        public int FabricYarnUnitId { get; set; }
        public double Price { get; set; }
    }
}
