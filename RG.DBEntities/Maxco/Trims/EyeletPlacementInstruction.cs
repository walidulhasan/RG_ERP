using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.FabricAndYarn;
using RG.DBEntities.Maxco.Setup;


namespace RG.DBEntities.Maxco.Trims
{
    public partial class EyeletPlacementInstruction
    {
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public int PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public int? UsePerPiece { get; set; }

        public virtual EyeletSpecification Object { get; set; }
        public virtual TrimPlacementInstruction_Setup PlacementInstruction { get; set; }
    }
}
