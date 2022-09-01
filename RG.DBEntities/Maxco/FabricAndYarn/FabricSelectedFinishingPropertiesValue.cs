using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSelectedFinishingPropertiesValue
    {
        public int Id { get; set; }
        public long? FabricSpecificationId { get; set; }
        public short? FinishingPropertiesValueId { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
        public virtual FabricFinishingPropertiesValueSetup FinishingPropertiesValue { get; set; }
    }
}
