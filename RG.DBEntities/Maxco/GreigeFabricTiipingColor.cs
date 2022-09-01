using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GreigeFabricTiipingColor
    {
        public int Id { get; set; }
        public int ColorSetId { get; set; }
        public int GreigeFabricTippingSpecificationId { get; set; }
        public string Pantone { get; set; }
        public byte DyeingMethodId { get; set; }
        public int? FabricYarnVendorColorId { get; set; }

        public virtual GreigeFabricTippingVeltSpecification GreigeFabricTippingSpecification { get; set; }
    }
}
