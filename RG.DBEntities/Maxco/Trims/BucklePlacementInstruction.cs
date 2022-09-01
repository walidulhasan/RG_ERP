using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
using RG.DBEntities.Maxco.FabricAndYarn;


namespace RG.DBEntities.Maxco.Trims
{
    public partial class BucklePlacementInstruction
    {
        public int ID { get; set; }
        public long ObjectID { get; set; }
        public int? PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public byte? UsePerPiece { get; set; }
        public string Location { get; set; }

        public virtual BuckleSpecification BuckleSpecification { get; set; }
       public virtual TrimPlacementInstruction_Setup PlacementInstruction { get; set; }
    }
}
