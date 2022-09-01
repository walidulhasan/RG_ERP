using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTippingColor
    {
        public int Id { get; set; }
        public int ColorSetId { get; set; }
        public int FabricTippingSpecificationId { get; set; }
        public string Pantone { get; set; }
        public byte DyeingMethodId { get; set; }
        public int? FabricYarnVendorColorId { get; set; }

        public virtual FabricTippingVeltSpecification FabricTippingSpecification { get; set; }
    }
}
