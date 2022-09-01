using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricTippingYarn
    {
        public int Id { get; set; }
        public int FabricTippingSpecificationId { get; set; }
        public long YarnSpecificationId { get; set; }
        public bool IsColorYarn { get; set; }
        public int ColorSetId { get; set; }

        public virtual FabricTippingVeltSpecification FabricTippingSpecification { get; set; }
    }
}
