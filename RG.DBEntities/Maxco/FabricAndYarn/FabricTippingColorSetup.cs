using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTippingColorSetup
    {
        public long Id { get; set; }
        public long ColorSetId { get; set; }
        public long FabricTippingSpecificationId { get; set; }
        public string Pantone { get; set; }
        public byte DyeingMethodId { get; set; }
        public int? FabricYarnVendorColorId { get; set; }
    }
}
