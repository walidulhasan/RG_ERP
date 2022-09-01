using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricWashingSpecification
    {
        public int Id { get; set; }
        public byte? WashingTypeId { get; set; }
        public int? FabricSpecificationId { get; set; }
        public byte? FabricWashingPropertyId { get; set; }
    }
}
