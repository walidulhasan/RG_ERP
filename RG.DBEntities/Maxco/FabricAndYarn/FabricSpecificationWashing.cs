using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricSpecificationWashing
    {
        public int Id { get; set; }
        public byte? WashingTypeId { get; set; }
        public long? FabricSpecificationId { get; set; }
        public byte? FabricWashingPropertyId { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
        public virtual FabricWashingPropertiesSetup FabricWashingProperty { get; set; }
    }
}
