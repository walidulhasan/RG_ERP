using System;
using System.Collections.Generic;
using RG.DBEntities.Maxco.Setup;
 
using RG.DBEntities.Maxco.FabricAndYarn;

namespace RG.DBEntities.Maxco.Trims
{
    public partial class ThreadPlacementInstruction
    {
        public int ID { get; set; }
        public int ObjectID { get; set; }
        public int? PlacementInstructionID { get; set; }
        public string OtherInstruction { get; set; }
        public int? DirectionID { get; set; }

        public virtual KajjingDirection_Setup Direction { get; set; }
        public virtual ThreadSpecification Object { get; set; }
        public virtual TrimPlacementInstruction_Setup PlacementInstruction { get; set; }
    }
}
