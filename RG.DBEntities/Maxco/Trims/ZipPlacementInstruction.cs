using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ZipPlacementInstruction
    {
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public int? PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public byte? UsePerPiece { get; set; }

        public virtual ZipSpecification Object { get; set; }
        public virtual TrimPlacementInstruction_Setup PlacementInstruction { get; set; }
    }
}
