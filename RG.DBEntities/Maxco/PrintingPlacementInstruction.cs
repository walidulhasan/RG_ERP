using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class PrintingPlacementInstruction
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public short? PlacementInstructionId { get; set; }
        public string OtherInstruction { get; set; }

        public virtual PrintingSpecification Object { get; set; }
        public virtual ElementPlacementInstructionsSetup PlacementInstruction { get; set; }
    }
}
