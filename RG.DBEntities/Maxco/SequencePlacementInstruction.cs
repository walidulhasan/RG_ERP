using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.Trims;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco
{
    public partial class SequencePlacementInstruction
    {
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public int PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public int? UsePerPiece { get; set; }

        public virtual SequenceSpecification Object { get; set; }
        public virtual TrimPlacementInstruction_Setup PlacementInstruction { get; set; }
    }
}
