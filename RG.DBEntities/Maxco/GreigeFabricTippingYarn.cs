using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco
{
    public partial class GreigeFabricTippingYarn
    {
        public int Id { get; set; }
        public int GreigeFabricTippingSpecificationId { get; set; }
        public long GreigeFabricYarnSpecificationId { get; set; }
        public bool IsColorYarn { get; set; }
        public int ColorSetId { get; set; }

        public virtual GreigeFabricTippingVeltSpecification GreigeFabricTippingSpecification { get; set; }
    }
}
