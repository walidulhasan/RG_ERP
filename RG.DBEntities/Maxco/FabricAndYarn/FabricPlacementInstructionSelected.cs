using RG.DBEntities.Maxco.Setup;
using System;
using System.Collections.Generic;

namespace RG.DBEntities.Maxco.FabricAndYarn
{
    public partial class FabricPlacementInstructionSelected
    {
        public int Id { get; set; }
        public long FabricSpecificationId { get; set; }
        public int? PlacementInstructionId { get; set; }
        public string OtherInstruction { get; set; }

        public virtual FabricSpecification FabricSpecification { get; set; }
        public virtual FabricTrimPlacementInstruction_Setup PlacementInstruction { get; set; }
    }
}
